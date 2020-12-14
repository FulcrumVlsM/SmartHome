using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Controller;
using SmartHome.Controller.Entities;
using System.Threading.Tasks;
using SmartHome.WebSocket.Models;
using System.Threading;

namespace SmartHome.WebSocket
{
    /// <summary>
    /// Обработчик соединения устройства с контроллером
    /// </summary>
    public class DeviceHandler : IDisposable
    {
        private readonly WebSocketWrapper<DeviceResponse, object> _webSocketWrapper;
        private readonly IEnumerable<BoolActionDeviceEntity> _entities;
        private bool disposedValue;

        public DeviceHandler(System.Net.WebSockets.WebSocket webSocket, IEnumerable<BoolActionDeviceEntity> actionDeviceEntities, CancellationToken cancellationToken)
        {
            if (webSocket is null) throw new ArgumentNullException(nameof(webSocket));
            if (actionDeviceEntities is null) throw new ArgumentNullException(nameof(actionDeviceEntities));

            _webSocketWrapper = new WebSocketWrapper<DeviceResponse, object>(webSocket, cancellationToken);
            _entities = actionDeviceEntities;
        }


        /// <summary>
        /// Текущий статус подключения
        /// </summary>
        public bool IsConnected => _webSocketWrapper.ClosedStatus;

        /// <summary>
        /// Связать подключения с контроллером
        /// </summary>
        public void Open()
        {
            foreach(var entity in _entities)
            {
                entity.OnStateChanged += Send;
            }
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
            await _webSocketWrapper.SendAndReceive(message);
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
        private async Task Close()
        {
            foreach (var entity in _entities)
            {
                try
                {
                    entity.OnStateChanged -= Send;
                }
                catch(Exception e)
                {
                    //TODO: Add log
                }
            }
            await _webSocketWrapper.Close();
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
