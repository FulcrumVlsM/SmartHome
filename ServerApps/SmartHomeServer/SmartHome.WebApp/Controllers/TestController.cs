using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.WebApp.Models;

namespace SmartHome.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var models = new List<TestModel>
            {
                 {new TestModel{ID = 1, Message = "Message1"} }
                ,{new TestModel{ID = 2, Message = "Message2"} }
            };
            return Ok(models);
        }
    }
}