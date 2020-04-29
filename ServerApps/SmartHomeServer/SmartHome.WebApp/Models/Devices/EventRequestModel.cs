using Newtonsoft.Json;
using SmartHome.Controller.Values;

namespace SmartHome.WebApp.Models.Devices
{
    public class EventRequestModel
    {
        [JsonProperty(PropertyName = "name")]
        public string SensorName { get; set; }


        [JsonIgnore]
        public DeviceEventWrapper DeviceEventWrapper => new DeviceEventWrapper(SensorName);
    }
}
