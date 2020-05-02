using Newtonsoft.Json;
using System;

namespace SmartHome.WebApp.Models.Devices
{
    public class BoolActionDeviceBindModel
    {
        [JsonProperty(PropertyName = "SysName")]
        public string SysName { get; set; }
    }
}
