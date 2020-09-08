using Newtonsoft.Json;
using System;

namespace SmartHome.WebSocket.Models
{
    public class BoolActionDeviceModel
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime DateTime { get; set; }

        [JsonProperty(PropertyName = "value")]
        public bool Value { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsSuccess { get; set; }
    }
}
