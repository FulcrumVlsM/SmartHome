﻿using Newtonsoft.Json;
using SmartHome.Controller.Values;

namespace SmartHome.WebApp.Models.Devices
{
    public class NumericSensorRequestModel
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string SensorName { get; set; }

        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        public float Value { get; set; }
    }
}
