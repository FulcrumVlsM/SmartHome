using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.WebApp.Hubs
{
    /// <summary>
    /// Хаб для логических исполнительных устройств
    /// </summary>
    public class ActionDeviceHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Send", message);
        }
    }
}
