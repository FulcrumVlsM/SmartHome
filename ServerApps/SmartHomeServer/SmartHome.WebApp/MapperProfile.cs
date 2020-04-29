using SmartHome.Data.Models;
using SmartHome.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.WebApp
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<BoolSensor, BoolSensorModel>();
            CreateMap<BoolSensorModel, BoolSensor>();
        }
    }
}
