using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHome.Controller;
using SmartHome.Controller.Values;
using SmartHome.WebApp.Models.Devices;

namespace SmartHome.WebApp.Controllers.Devices
{
    [Route("api/event-device")]
    [ApiController]
    public class EventDeviceController : ControllerBase
    {
        private readonly IDeviceController _deviceController;
        private readonly IMapper _mapper;
        private readonly ILogger<EventDeviceController> _logger;

        public EventDeviceController(IDeviceController deviceController, IMapper mapper, ILogger<EventDeviceController> logger)
        {
            _deviceController = deviceController;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Post(EventRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _deviceController.ThrowEvent(_mapper.Map<DeviceEventWrapper>(model)))
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