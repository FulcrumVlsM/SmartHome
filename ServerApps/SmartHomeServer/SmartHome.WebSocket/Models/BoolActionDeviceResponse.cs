﻿using Newtonsoft.Json;

namespace SmartHome.WebSocket.Models
{
    public class BoolActionDeviceResponse
    {
        [JsonProperty(PropertyName = "response-type")]
        public ResponseType ResponseType { get; set; }

        [JsonProperty(PropertyName = "device-type")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName = "sysname")]
        public string SysName { get; set; }
    }
}
