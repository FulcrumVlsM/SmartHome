using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHome.Controller;

namespace SmartHome.WebApp.Controllers.Devices
{
    //[Route("api/action-device/[action]")]
    public class ActionDeviceController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IDeviceController _controller;
        private readonly ILogger<ActionDeviceController> _logger;

        public ActionDeviceController(IDeviceController controller, ILogger<ActionDeviceController> logger)
        {
            _controller = controller;
            _logger = logger;
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
                
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
