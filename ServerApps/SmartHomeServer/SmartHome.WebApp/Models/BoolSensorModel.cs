using SmartHome.Common.Enums;
using System;
using Newtonsoft.Json;

namespace SmartHome.WebApp.Models
{
    public class BoolSensorModel
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "SysName")]
        public string SysName { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty(PropertyName = "LastActivity")]
        public DateTime LastActivity { get; set; }

        [JsonProperty(PropertyName = "IsActive")]
        public bool ActivityMode { get; set; }

        [JsonProperty(PropertyName = "Category")]
        public DeviceCategory Category { get; set; }

        //TODO: Conditions
    }
}
