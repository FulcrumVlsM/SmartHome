using System;
using SmartHome.Common.Enums;

namespace SmartHome.Data.Models
{
    public class BoolDeviceEventAction
    {
        public int EventDeviceID { get; set; }
        public EventDevice EventDevice { get; set; }

        public int BoolActionDeviceID { get; set; }
        public BoolActionDevice Device { get; set; }

        public DeviceStateMode TargetStateMode { get; set; }
    }
}
