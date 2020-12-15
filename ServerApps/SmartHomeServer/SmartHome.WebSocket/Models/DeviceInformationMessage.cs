using Newtonsoft.Json;

namespace SmartHome.WebSocket.Models
{
    public class DeviceInformationMessage
    {
        [JsonProperty(PropertyName = "configuration")]
        public Configuration Configuration { get; set; }

        [JsonProperty(PropertyName = "information-type")]
        public InformationType InformationType { get; set; }
    }
}
