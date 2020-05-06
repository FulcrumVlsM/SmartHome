using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Store;
using SmartHome.WebApp.Models;

namespace SmartHome.WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IDataStore _dataStore;

        public TestController(IStoreFactory storeFactory)
        {
            _dataStore = storeFactory.ConfigurationDataStore;
        }


        [HttpGet]
        //[Route("api/[controller]")]
        public IActionResult Get()
        {
            var models = new List<TestModel>
            {
                 {new TestModel{ID = 1, Message = "Message1"} }
                ,{new TestModel{ID = 2, Message = "Message2"} }
            };
            return Ok(models);
        }

        [HttpGet]
        //[Route("api/[controller]/GetBoolSensors")]
        public IActionResult GetBoolSensors()
        {
            return Ok(_dataStore.BoolSensors);
        }
    }
}