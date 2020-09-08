using Newtonsoft.Json;
using SmartHome.Controller;
using SmartHome.Controller.Entities;
using SmartHome.WebSocket.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.WebSocket
{
    public class WebSocketDeviceManager : WebSocketWrapper
    {
        private readonly IDeviceController _controller;

        public WebSocketDeviceManager(System.Net.WebSockets.WebSocket webSocket, IDeviceController controller) : base(webSocket)
        {
            _controller = controller;
        }


        public async Task<bool> Configure()
        {
            if (base.IsActive)
            {
                var message = await base.ReceiveMessage();
                var configuration = JsonConvert.DeserializeObject<DeviceConfigurationModel>(message);
                switch (configuration.DeviceType)
                {
                    case DeviceType.BoolActionDevice:
                        await ConfigureBoolActionDevice(configuration.SysName);
                        break;
                    case DeviceType.EventActionDevice:
                        break;
                    default: throw new Exception($"Недопустимое значение перечисления {nameof(DeviceType)}");
                }
                return true;
            }
            return false;
        }


        private async Task ConfigureBoolActionDevice(string sysName)
        {
            if(_controller.TryGetBoolActionDeviceEntity(sysName, out BoolActionDeviceEntity entity))
            {
                var wrapper = new BoolActionDeviceWebSocketWrapper(base._webSocket, entity);
                await wrapper.SendInitiateMessage();
            }
        }

        private async Task ConfigureEventActionDevice(string sysName)
        {

        }
    }
}
