using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Controller;
using SmartHome.Controller.Values;
using SmartHome.WebApp.Models.Devices;

namespace SmartHome.WebApp.Controllers.Devices
{
    [Route("api/bool-sensor")]
    [ApiController]
    public class BoolSensorController : ControllerBase
    {
        private readonly IDeviceController _deviceController;
        private readonly IMapper _mapper;

        public BoolSensorController(IDeviceController deviceController, IMapper mapper)
        {
            _deviceController = deviceController;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(BoolSensorRequestModel model)
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