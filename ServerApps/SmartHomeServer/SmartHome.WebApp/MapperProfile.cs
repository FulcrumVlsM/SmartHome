using SmartHome.Controller.Models;
using SmartHome.Controller.Values;
using SmartHome.Data.Models;
using SmartHome.WebApp.Extensions;
using SmartHome.WebApp.Models;
using SmartHome.WebApp.Models.Devices;
using SmartHome.WebApp.Models.State;
using System;
using System.Collections.Generic;

namespace SmartHome.WebApp
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            AllowNullCollections = true;

            //Маппинг для CRUD моделей
            CreateMap<BoolSensor, BoolSensorModel>();
            CreateMap<BoolSensorModel, BoolSensor>();
            CreateMap<BoolActionDevice, BoolActionDeviceModel>();
            CreateMap<BoolActionDeviceModel, BoolActionDevice>();


            //Маппинг для моделей API устройств
            CreateMap<NumericSensorRequestModel, NumericSensorValue>();
            CreateMap<EventRequestModel, DeviceEventWrapper>();
            CreateMap<BoolSensorRequestModel, BoolSensorValue>();

            //Маппинг для моделей мониторинга
            CreateMap<NumericSensor, TemperatureSensorModel>();
            CreateMap<NumericSensor, HimiditySensorModel>();
            CreateMap<NumericSensor, DioxideSensorModel>();

            CreateMap<Summary, StateModel>()
                .ForMember(state => state.TemperatureState, x => x.MapFrom(summary => summary.TemperatureSummary))
                .ForMember(state => state.HimidityState, x => x.MapFrom(summary => summary.HimiditySummary))
                .ForMember(state => state.DioxideState, x => x.MapFrom(summary => summary.DioxideSummary))
                .ForMember(state => state.ActiveDevices, x => x.MapFrom(summary => summary.ActiveDevices));

            CreateMap<SensorSummary, TemperatureStateModel>()
                .ForMember(state => state.Sensors, x => x.MapFrom(summary => summary.Sensors))
                .ForMember(state => state.History, x => x.MapFrom(summary => summary.History));

            CreateMap<SensorSummary, HimidityStateModel>()
                .ForMember(state => state.Sensors, x => x.MapFrom(summary => summary.Sensors));

            CreateMap<SensorSummary, DioxideStateModel>()
                .ForMember(state => state.Sensors, x => x.MapFrom(summary => summary.Sensors));

            CreateMap<IEnumerable<NumericSensorHistoryItem>, Dictionary<DateTime, float>>()
                .ConvertUsing<BoolActionDeviceToDictionaryConverter>();
        }
    }
}
