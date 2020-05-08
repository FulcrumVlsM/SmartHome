using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SmartHome.Controller;
using SmartHome.Data.Models;
using SmartHome.WebApp.Models.Devices;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHome.WebApp.Hubs
{
    /// <summary>
    /// Хаб для событийный исполнительных устройств
    /// </summary>
    public class EventActionDeviceHub : Hub
    {
        private const string BIND_SUCCESSFUL_METHOD = "BindSuccessful";
        private const string FAIL_METHOD = "Fail";
        private const string SET_VALUE_METHOD = "SetValue";

        private static ConcurrentDictionary<string, List<string>> _connectionStore;
        private static ReaderWriterLockSlim _locker;

        private readonly IDeviceController _controller;
        private readonly ILogger<EventActionDeviceHub> _logger;

        static EventActionDeviceHub()
        {
            _connectionStore = new ConcurrentDictionary<string, List<string>>();
            _locker = new ReaderWriterLockSlim();
        }

        public EventActionDeviceHub(IDeviceController controller, ILogger<EventActionDeviceHub> logger)
        {
            _controller = controller;
            _logger = logger;
        }


        public async Task Registry(EventActionDeviceBindModel bindingDevice)
        {
            var sysName = bindingDevice.SysName;
            if (string.IsNullOrWhiteSpace(sysName))
            {
                _logger.LogError("При регистрации не было передано имя устройства");
                await Clients.Caller.SendAsync(FAIL_METHOD);
                return;
            }

            if(_connectionStore.TryGetValue(sysName, out List<string> connections))
            {
                _logger.LogTrace($"Добавлено подключение '{Context.ConnectionId}' для текущего устройства '{sysName}'");
                connections.Add(Context.ConnectionId);
            }
            else
            {
                _connectionStore.TryAdd(sysName, new List<string>() { Context.ConnectionId });
                _logger.LogInformation($"Добавлено подключение '{Context.ConnectionId}' для нового устройства '{sysName}'");
                _controller.RegistryEventActionDeviceHandler(sysName, async () =>
                {
                    _locker.EnterReadLock();
                    try
                    {
                        if (_connectionStore.TryGetValue(sysName, out List<string> connections))
                            await Clients.Clients(connections).SendAsync(SET_VALUE_METHOD);
                    }
                    finally
                    {
                        _locker.ExitReadLock();
                    }
                });
                _logger.LogTrace($"Обработчик для устройства '{sysName}' зарегистрирован в контроллере");
            }
            await Clients.Caller.SendAsync(BIND_SUCCESSFUL_METHOD);
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            _locker.EnterWriteLock();
            try
            {
                var connectionId = Context.ConnectionId;
                var device = _connectionStore.FirstOrDefault(deviceConnections => deviceConnections.Value.Contains(connectionId)).Key;
                _logger.LogInformation($"Закрыто подключение '{connectionId}', привязанное к устройству '{device}'");

                if (_connectionStore.TryGetValue(device, out List<string> connectionIdList))
                    connectionIdList.Remove(connectionId);

                return base.OnDisconnectedAsync(exception);
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }
    }
}
