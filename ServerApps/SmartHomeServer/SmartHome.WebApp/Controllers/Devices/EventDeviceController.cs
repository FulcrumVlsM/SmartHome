using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Controller;
using SmartHome.WebApp.Models.Devices;

namespace SmartHome.WebApp.Controllers.Devices
{
    [Route("api/event-device/bool")]
    [ApiController]
    public class EventDeviceController : ControllerBase
    {
        private readonly IDeviceController _deviceController;

        public EventDeviceController(IDeviceController deviceController)
        {
            _deviceController = deviceController;
        }


        [HttpPost]
        public IActionResult Post(EventRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_deviceController.ThrowEvent(model.DeviceEventWrapper))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}