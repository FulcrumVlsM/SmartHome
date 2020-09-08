using Newtonsoft.Json;
using SmartHome.Controller.Entities;
using SmartHome.WebSocket.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.WebSocket
{
    public sealed class BoolActionDeviceWebSocketWrapper : WebSocketWrapper
    {
        private BoolActionDeviceEntity _entity;
        
        public BoolActionDeviceWebSocketWrapper(System.Net.WebSockets.WebSocket webSocket, BoolActionDeviceEntity entity) : base(webSocket)
        {
            _entity = entity;
            _entity.OnStateChanged += Send;
        }


        private async Task Send(bool value)
        {
            if (!base.IsActive)
            {
                _entity.OnStateChanged -= Send;
            }
            
            var boolActionDeviceMessage = new BoolActionDeviceModel()
            {
                DateTime = DateTime.Now,
                Value = value,
                IsSuccess = true
            };
            string message = JsonConvert.SerializeObject(boolActionDeviceMessage);
            await base.SendMessage(message);
        }

        public async Task SendInitiateMessage()
        {
            var boolActionDeviceMessage = new BoolActionDeviceModel()
            {
                DateTime = DateTime.Now,
                Value = _entity.Value,
                IsSuccess = true
            };
            string message = JsonConvert.SerializeObject(boolActionDeviceMessage);
            await base.SendMessage(message);
        }
    }
}
