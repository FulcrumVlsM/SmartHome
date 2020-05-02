using Newtonsoft.Json;

namespace SmartHome.WebApp.Models.Devices
{
    public class EventRequestModel
    {
        [JsonProperty(PropertyName = "name")]
        public string SensorName { get; set; }
    }
}
