using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHome.Data.Store;
using SmartHome.WebApp.Models;

namespace SmartHome.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoolSensorsController : ControllerBase
    {
        private readonly IRepository<BoolSensor> _sensorRepository;
        private readonly IMapper _mapper;

        public BoolSensorsController(IStoreFactory storeFactory, IMapper mapper)
        {
            _sensorRepository = storeFactory.ConfigurationDataStore.BoolSensors;
            _mapper = mapper;
        }



        [HttpGet]
        public IEnumerable<BoolSensorModel> Get() => _mapper.Map<IEnumerable<BoolSensor>, IEnumerable<BoolSensorModel>>(_sensorRepository);


        [HttpGet("{id}")]
        public BoolSensorModel Get(int id) => _mapper.Map<BoolSensorModel>(_sensorRepository[id]);


        [HttpPost]
        public IActionResult Post(BoolSensorModel model)
        {
            if (ModelState.IsValid)
            {
                _sensorRepository.Add(_mapper.Map<BoolSensor>(model));
                _sensorRepository.Save();
                return Ok(model);
            }
            else return BadRequest(ModelState);
        }


        [HttpPut]
        public IActionResult Put(BoolSensorModel model)
        {
            if (ModelState.IsValid)
            {
                _sensorRepository.Update(_mapper.Map<BoolSensor>(model));
                _sensorRepository.Save();
                return Ok(model);
            }
            else return BadRequest(ModelState);
        }


        public IActionResult Delete(int id)
        {
            if (_sensorRepository.Delete(id)) _sensorRepository.Save();
            return Ok();
        }
    }
}