using SmartHome.Controller.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.WebSocket
{
    public class EventActionDeviceWebSocketWrapper : WebSocketWrapper
    {
        private readonly EventActionDeviceEntity _entity;

        public EventActionDeviceWebSocketWrapper(System.Net.WebSockets.WebSocket webSocket, EventActionDeviceEntity entity) : base(webSocket)
        {
            _entity = entity;
        }
    }
}
