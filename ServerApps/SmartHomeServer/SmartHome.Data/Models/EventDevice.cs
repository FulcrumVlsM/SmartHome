using System;
using System.Collections.Generic;
using SmartHome.Common.Enums;

namespace SmartHome.Data.Models
{
    public class EventDevice
    {
        public int ID { get; set; }

        public string Name { get; set; }
        
        public string SysName { get; set; }

        public bool Enable { get; set; }

        public bool IsSmartCardEventEnable { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastEventDate { get; set; }

        public DeviceCategory Category { get; set; }


        public int UserEventActionID { get; set; }

        public UserEventAction UserEventAction { get; set; }


        public ICollection<Rule2EventDevice> Rule2EventDevices { get; set; }

        public ICollection<BoolDeviceEventAction> BoolDeviceActions { get; set; }

        public ICollection<EventDevice2EventActionDevice> EventDevice2EventActionDevices { get; set; }
    }
}
