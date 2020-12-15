using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Controller;
using SmartHome.Controller.Entities;
using System.Threading.Tasks;
using SmartHome.WebSocket.Models;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace SmartHome.WebSocket
{
    /// <summary>
    /// Обработчик соединения устройства с контроллером
    /// </summary>
    public class DeviceHandler : IDisposable
    {
        private readonly WebSocketWrapper<DeviceResponse, DeviceInformationMessage> _webSocketWrapper;
        private readonly IEnumerable<BoolActionDeviceEntity> _entities;
        private readonly ILogger _logger;
        private bool disposedValue;

        public DeviceHandler(System.Net.WebSockets.WebSocket webSocket, IEnumerable<BoolActionDeviceEntity> actionDeviceEntities, CancellationToken cancellationToken, ILogger logger)
        {
            if (webSocket is null) throw new ArgumentNullException(nameof(webSocket));
            if (actionDeviceEntities is null) throw new ArgumentNullException(nameof(actionDeviceEntities));
            if (logger is null) throw new ArgumentNullException(nameof(logger));

            _webSocketWrapper = new WebSocketWrapper<DeviceResponse, DeviceInformationMessage>(webSocket, cancellationToken);
            _entities = actionDeviceEntities;
            _logger = logger;
        }


        /// <summary>
        /// Текущий статус подключения
        /// </summary>
        public bool IsConnected => _webSocketWrapper.ClosedStatus;

        /// <summary>
        /// Связать подключения с контроллером
        /// </summary>
        public async Task Open()
        {
            //foreach(var entity in _entities)
            //{                
            //    entity.OnStateChanged += Send;
            //}
            await Task.Run(Fake);
        }

        /// <summary>
        /// Передать событие на исполнительное устройство
        /// </summary>
        private async Task Send(string sysName)
        {
            var message = new DeviceResponse()
            {
                ResponseType = ResponseType.Update,
                DeviceType = DeviceType.EventActionDevice,
                SysName = sysName
            };
            var responseMessage = await _webSocketWrapper.SendAndReceive(message);
            if(responseMessage?.Configuration?.SysName != sysName)
            {
                //Запись в лог сообщения о некорректном сообщении от устройства
            }
        }

        /// <summary>
        /// Передать событие на логическое устройство
        /// </summary>
        private async Task Send(string sysName, bool state)
        {
            var message = new DeviceResponse()
            {
                ResponseType = ResponseType.Update,
                DeviceType = DeviceType.BoolActionDevice,
                SysName = sysName,
                Value = state
            };
            await _webSocketWrapper.SendAndReceive(message);
        }


        /// <summary>
        /// Передать сообщение по умолчанию (чтобы не потерять подключение по таймауту)
        /// </summary>
        private async Task SendDefault()
        {
            var message = new DeviceResponse()
            {
                ResponseType = ResponseType.StandBy,
                DeviceType = DeviceType.None
            };
            await _webSocketWrapper.SendAndReceive(message);
        }


        /// <summary>
        /// Закрыть подключение
        /// </summary>
        public async Task Close()
        {
            //foreach (var entity in _entities)
            //{
            //    try
            //    {
            //        entity.OnStateChanged -= Send;
            //    }
            //    catch(Exception e)
            //    {
            //        //TODO: Add log
            //    }
            //}
            await _webSocketWrapper.Close();
        }


        private async Task Fake()
        {
            while (IsConnected)
            {
                await Send("bool_device1", true);
                await Task.Delay(1000);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _webSocketWrapper.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
