using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Controller;
using SmartHome.WebApp.Models;

namespace SmartHome.WebApp.Controllers.Devices
{
    [Route("api/sensor/numeric")]
    [ApiController]
    public class NumericSensorController : ControllerBase
    {
        private readonly IDeviceController _deviceController;

        public NumericSensorController(IDeviceController deviceController)
        {
            _deviceController = deviceController;
        }


        public IActionResult Post(NumericSensorRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_deviceController.PassValue(model.NumericSensorValue))
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