using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        private CancellationToken _cancellationToken;


        public ConnectionInitializeWorker(System.Net.WebSockets.WebSocket webSocket, IDeviceController controller, CancellationToken cancellationToken, ILogger logger)
        {
            _webSocket = webSocket;
            _controller = controller;
            _cancellationToken = cancellationToken;
            _logger = logger;
        }


        public async Task<DeviceHandler> Initialize()
        {
            var entities = new List<BoolActionDeviceEntity>();
            DeviceConnectionRequest request;

            using (var wrapper = new WebSocketWrapper<object, DeviceConnectionRequest>(_webSocket, _cancellationToken))
            {
                request = await wrapper.Receive();
            }

            //TODO: вынести в отдельный метод
            using (var wrapper = new WebSocketWrapper<DeviceResponse, DeviceInformationMessage>(_webSocket, _cancellationToken))
            {
                foreach (var configuration in request.Configurations)
                {
                    if (configuration.DeviceType == DeviceType.BoolActionDevice)
                    {
                        if(_controller.TryGetBoolActionDeviceEntity(configuration.SysName, out var entity))
                        {
                            var serverMessage = new DeviceResponse()
                            {
                                ResponseType = ResponseType.Update,
                                DeviceType = DeviceType.BoolActionDevice,
                                SysName = entity.SysName,
                                Value = entity.Value
                            };
                            var clientMessage = await wrapper.SendAndReceive(serverMessage);

                            _logger.LogInformation($"Открыто новое подключение. Устройство: {serverMessage.SysName}, Ответ устройства: {clientMessage.InformationType}");

                            if(!ValidateDeviceInformationMessage(serverMessage, clientMessage))
                            {
                                _logger.LogWarning($"Устройство предоставило некорректный ответ. " +
                                    $"{serverMessage?.SysName}:{clientMessage?.Configuration?.SysName}, {serverMessage?.DeviceType}:{clientMessage?.Configuration?.DeviceType}");
                            }
                            entities.Add(entity);
                        }
                    }
                    //TODO: событийные устройства
                }
            }

                return new DeviceHandler(_webSocket, entities, _cancellationToken, _logger);
        }



        private bool ValidateDeviceInformationMessage(DeviceResponse serverMessage, DeviceInformationMessage clientMessage)
        {
            return serverMessage.DeviceType == clientMessage?.Configuration?.DeviceType
                && serverMessage.SysName == clientMessage?.Configuration?.SysName;
        }
    }
}
