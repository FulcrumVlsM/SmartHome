using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.TestWebSocketClientApp.Models
{
    class BoolDeviceModel
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime DateTime { get; set; }

        [JsonProperty(PropertyName = "value")]
        public bool Value { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsSuccess { get; set; }
    }
}
