using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Controller;
using SmartHome.WebApp.Models;

namespace SmartHome.WebApp.Controllers.Devices
{
    [Route("api/sensor/bool")]
    [ApiController]
    public class BoolSensorController : ControllerBase
    {
        private readonly IDeviceController _deviceController;

        public BoolSensorController(IDeviceController deviceController)
        {
            _deviceController = deviceController;
        }

        [HttpPost]
        public IActionResult Post(BoolSensorRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_deviceController.PassValue(model.BoolSensorValue))
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