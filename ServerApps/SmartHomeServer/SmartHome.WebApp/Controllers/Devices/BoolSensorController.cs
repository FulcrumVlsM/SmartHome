using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<BoolSensorController> _logger;

        public BoolSensorController(IDeviceController deviceController, IMapper mapper, ILogger<BoolSensorController> logger)
        {
            _deviceController = deviceController;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(BoolSensorRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Невалидный параметр {nameof(BoolSensorRequestModel)}");
                return BadRequest();
            }

            if (_deviceController.PassValue(_mapper.Map<BoolSensorValue>(model)))
            {
                _logger.LogTrace($"Получены данные от {model.SensorName}: {model.Value}");
                return Ok();
            }
            else
            {
                _logger.LogError($"Не удалось передать от {model.SensorName} ({model.Value})");
                return BadRequest();
            }
        }
    }
}