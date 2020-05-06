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
    /// Хаб для логических исполнительных устройств
    /// </summary>
    public class ActionDeviceHub : Hub
    {
        private const string BIND_SUCCESSFUL_METHOD = "BindSuccessful";
        private const string FAIL_METHOD = "Fail";
        private const string SET_VALUE_METHOD = "SetValue";

        private static ConcurrentDictionary<string, List<string>> _connections;
        private static ReaderWriterLockSlim _locker;
        
        private readonly IDeviceController _controller;


        static ActionDeviceHub()
        {
            _connections = new ConcurrentDictionary<string, List<string>>();
            _locker = new ReaderWriterLockSlim();
        }

        public ActionDeviceHub(IDeviceController controller)
        {
            _controller = controller;
        }



        public async Task Registry(BoolActionDeviceBindModel bindingDevice)
        {
            var sysName = bindingDevice.SysName;
            if (string.IsNullOrWhiteSpace(sysName))
            {
                await Clients.Caller.SendAsync(FAIL_METHOD);
                return;
            }

            if(_connections.TryGetValue(sysName, out List<string> connections))
            {
                connections.Add(Context.ConnectionId);
            }
            else
            {
                _connections.TryAdd(sysName, new List<string>() { Context.ConnectionId });
                _controller.RegistryBoolActionDeviceHandler(sysName, async (value) =>
                {
                    _locker.EnterReadLock();
                    try
                    {
                        if (_connections.TryGetValue(sysName, out List<string> connectionIdList))
                            await Clients.Clients(connectionIdList).SendAsync(SET_VALUE_METHOD, value);
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
            _locker.EnterWriteLock();
            try
            {
                var connectionId = Context.ConnectionId;
                var device = _connections.FirstOrDefault(deviceConnections => deviceConnections.Value.Contains(connectionId)).Key;

                if (_connections.TryGetValue(device, out List<string> connectionIdList))
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
