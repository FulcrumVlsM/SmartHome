using Newtonsoft.Json;
using SmartHome.Common.Enums;
using System;

namespace SmartHome.WebApp.Models
{
    public class BoolActionDeviceModel
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "SysName")]
        public string SysName { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ActivityMode")]
        public DeviceStateMode ActivityMode { get; set; }

        [JsonProperty(PropertyName = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty(PropertyName = "LastActivityDate")]
        public DateTime LastActivityDate { get; set; }

        [JsonProperty(PropertyName = "Category")]
        public DeviceCategory Category { get; set; }
    }
}
