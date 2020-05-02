using SmartHome.Controller.Values;
using SmartHome.Data.Models;
using SmartHome.WebApp.Models;
using SmartHome.WebApp.Models.Devices;
using System;
using System.Collections.Generic;

namespace SmartHome.WebApp
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            //Маппинг для CRUD моделей
            CreateMap<BoolSensor, BoolSensorModel>();
            CreateMap<BoolSensorModel, BoolSensor>();


            //Маппинг для моделей API устройств
            CreateMap<NumericSensorRequestModel, NumericSensorValue>();
            CreateMap<EventRequestModel, DeviceEventWrapper>();
            CreateMap<BoolSensorRequestModel, BoolSensorValue>();
        }
    }
}
