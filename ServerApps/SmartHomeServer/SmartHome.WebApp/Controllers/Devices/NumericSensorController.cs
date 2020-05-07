using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHome.Controller;
using SmartHome.Controller.Values;
using SmartHome.WebApp.Models.Devices;

namespace SmartHome.WebApp.Controllers.Devices
{
    [Route("api/numeric-sensor")]
    [ApiController]
    public class NumericSensorController : ControllerBase
    {
        private readonly IDeviceController _deviceController;
        private readonly IMapper _mapper;
        private readonly ILogger<NumericSensorController> _logger;

        public NumericSensorController(IDeviceController deviceController, IMapper mapper, ILogger<NumericSensorController> logger)
        {
            _deviceController = deviceController;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult Post(NumericSensorRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_deviceController.PassValue(_mapper.Map<BoolSensorValue>(model)))
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