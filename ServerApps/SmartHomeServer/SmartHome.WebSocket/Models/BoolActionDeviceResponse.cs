using Newtonsoft.Json;

namespace SmartHome.WebSocket.Models
{
    public class DeviceResponse
    {
        [JsonProperty(PropertyName = "response-type")]
        public ResponseType ResponseType { get; set; }

        [JsonProperty(PropertyName = "device-type")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName = "sysname")]
        public string SysName { get; set; }

        [JsonProperty(PropertyName = "value")]
        public bool Value { get; set; }
    }
}
