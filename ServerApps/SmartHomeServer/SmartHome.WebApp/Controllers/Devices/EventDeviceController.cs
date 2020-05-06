using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Controller;
using SmartHome.Controller.Values;
using SmartHome.WebApp.Models.Devices;

namespace SmartHome.WebApp.Controllers.Devices
{
    [Route("api/event-device/bool")]
    [ApiController]
    public class EventDeviceController : ControllerBase
    {
        private readonly IDeviceController _deviceController;
        private readonly IMapper _mapper;

        public EventDeviceController(IDeviceController deviceController, IMapper mapper)
        {
            _deviceController = deviceController;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Post(EventRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_deviceController.ThrowEvent(_mapper.Map<DeviceEventWrapper>(model)))
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