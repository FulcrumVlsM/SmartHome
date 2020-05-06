using Newtonsoft.Json;

namespace SmartHome.WebApp.Models.Devices
{
    public class EventActionDeviceBindModel
    {
        [JsonProperty(PropertyName = "SysName")]
        public string SysName { get; set; }
    }
}
