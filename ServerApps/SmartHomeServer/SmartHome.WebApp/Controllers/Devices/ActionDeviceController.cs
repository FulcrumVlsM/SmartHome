using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartHome.Controller;
using SmartHome.WebSocket;

namespace SmartHome.WebApp.Controllers.Devices
{
    //[Route("api/action-device/[action]")]
    public class ActionDeviceController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IDeviceController _controller;
        private readonly ILogger<ActionDeviceController> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        //TODO: inject IHostApplicationLifetime
        public ActionDeviceController(IDeviceController controller, ILogger<ActionDeviceController> logger, IHostApplicationLifetime hostApplicationLifetime)
        {
            _controller = controller;
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        [Route("api/action-device/hello")]
        public string Hello()
        {
            return "Hello!";
        }


        [Route("api/action-device/connect")]
        public async Task Connect()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var initializer = new ConnectionInitializeWorker(webSocket, _controller, _hostApplicationLifetime.ApplicationStopping, _logger);
                await Echo(initializer);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogWarning("Запрос к api/action-device/connect заблокирован, т.к. не являлся web socket запросом");
            }
        }



        private async Task Echo(ConnectionInitializeWorker initializer)
        {
            using (var deviceHandler = await initializer.Initialize())
            {
                await deviceHandler.Open();
                _logger.LogInformation($"Открыто web socket подключение c клиентом {HttpContext.Connection.RemoteIpAddress}");

                while(!_hostApplicationLifetime.ApplicationStopping.IsCancellationRequested && deviceHandler.IsConnected)
                {
                    await Task.Delay(10000);
                }

                await deviceHandler.Close();
                _logger.LogInformation($"Закрыто web socket подключение c клиентом {HttpContext.Connection.RemoteIpAddress}");
            }
        }
    }
}
