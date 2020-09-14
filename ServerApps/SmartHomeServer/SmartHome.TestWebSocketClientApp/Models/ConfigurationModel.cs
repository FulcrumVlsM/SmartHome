using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.TestWebSocketClientApp.Models
{
    public class ConfigurationModel
    {
        [JsonProperty(PropertyName = "device_type")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty(PropertyName = "sys_name")]
        public string SysName { get; set; }
    }
}
