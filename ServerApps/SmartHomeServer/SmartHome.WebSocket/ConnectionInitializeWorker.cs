using Newtonsoft.Json;
using SmartHome.Controller;
using SmartHome.Controller.Entities;
using SmartHome.WebSocket.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHome.WebSocket
{
    public class ConnectionInitializeWorker
    {
        private readonly System.Net.WebSockets.WebSocket _webSocket;
        private readonly IDeviceController _controller;


        public ConnectionInitializeWorker(System.Net.WebSockets.WebSocket webSocket, IDeviceController controller)
        {
            _webSocket = webSocket;
            _controller = controller;
        }


        public async Task<bool> Initialize()
        {
            var inputBuffer = new byte[1024 * 4];
            await _webSocket.ReceiveAsync(new ArraySegment<byte>(inputBuffer), CancellationToken.None);
            string message = Encoding.Unicode.GetString(inputBuffer);
            var request = JsonConvert.DeserializeObject<DeviceRequest>(message);
            var entities = new List<BoolActionDeviceEntity>();

            foreach(var configuration in request.Configurations)
            {
                if (configuration.DeviceType == DeviceType.BoolActionDevice)
                {
                    _controller.TryGetBoolActionDeviceEntity(configuration.SysName, out var entity);
                    entities.Add(entity);
                }
                //TODO: событийные устройства
            }

            var wrapper = new DeviceHandler(_webSocket, entities);
            wrapper.Open();

            return false;
        }
    }
}
