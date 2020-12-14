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
    /// <summary>
    /// Обработчик для инициализации подключения
    /// </summary>
    public class ConnectionInitializeWorker
    {
        private readonly System.Net.WebSockets.WebSocket _webSocket;
        private readonly IDeviceController _controller;
        private CancellationToken _cancellationToken;


        public ConnectionInitializeWorker(System.Net.WebSockets.WebSocket webSocket, IDeviceController controller, CancellationToken cancellationToken)
        {
            _webSocket = webSocket;
            _controller = controller;
            _cancellationToken = cancellationToken;
        }


        public async Task<DeviceHandler> Initialize()
        {
            var entities = new List<BoolActionDeviceEntity>();

            using (var wrapper = new WebSocketWrapper<object, DeviceRequest>(_webSocket, _cancellationToken))
            {
                var request = await wrapper.Receive();

                foreach (var configuration in request.Configurations)
                {
                    if (configuration.DeviceType == DeviceType.BoolActionDevice)
                    {
                        _controller.TryGetBoolActionDeviceEntity(configuration.SysName, out var entity);
                        entities.Add(entity);
                    }
                    //TODO: событийные устройства
                }
            }

            return new DeviceHandler(_webSocket, entities, _cancellationToken);
        }
    }
}
