using Newtonsoft.Json;

namespace SmartHome.WebSocket.Models
{
    internal class DeviceConfigurationModel
    {
        [JsonProperty(PropertyName = "device_type")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName = "sys_name")]
        public string SysName { get; set; }
    }
}
