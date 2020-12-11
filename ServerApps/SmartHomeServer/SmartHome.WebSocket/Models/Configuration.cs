using Newtonsoft.Json;

namespace SmartHome.WebSocket.Models
{
    public class Configuration
    {
        [JsonProperty(PropertyName = "device_type")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName = "sys_name")]
        public string SysName { get; set; }
    }
}
