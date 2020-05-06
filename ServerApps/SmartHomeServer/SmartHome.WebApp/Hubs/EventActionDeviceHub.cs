using Microsoft.AspNetCore.SignalR;
using SmartHome.Controller;
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

        static EventActionDeviceHub()
        {
            _connectionStore = new ConcurrentDictionary<string, List<string>>();
            _locker = new ReaderWriterLockSlim();
        }

        public EventActionDeviceHub(IDeviceController controller)
        {
            _controller = controller;
        }


        public async Task Registry(EventActionDeviceBindModel bindingDevice)
        {
            var sysName = bindingDevice.SysName;
            if (string.IsNullOrWhiteSpace(sysName))
            {
                await Clients.Caller.SendAsync(FAIL_METHOD);
                return;
            }

            if(_connectionStore.TryGetValue(sysName, out List<string> connections))
            {
                connections.Add(Context.ConnectionId);
            }
            else
            {
                _connectionStore.TryAdd(sysName, new List<string>() { Context.ConnectionId });
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
            }
            await Clients.Caller.SendAsync(BIND_SUCCESSFUL_METHOD);
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
