using SmartHome.Controller.Values;
using Newtonsoft.Json;

namespace SmartHome.WebApp.Models.Devices
{
    public class BoolSensorRequestModel
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string SensorName { get; set; }

        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        public bool Value { get; set; }


        [JsonIgnore]
        public BoolSensorValue BoolSensorValue => new BoolSensorValue { SensorName = SensorName, Value = Value };
    }
}
