using System;
using System.Collections.Generic;
using SmartHome.Common.Enums;

namespace SmartHome.Data.Models
{
    public class BoolActionDevice
    {
        public int ID { get; set; }
        
        public string SysName { get; set; }
        
        public string Name { get; set; }
        
        public DeviceStateMode ActivityMode { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastActivityDate { get; set; }

        public DeviceCategory Category { get; set; }


        public List<Rule2BoolActionDevice> Rule2BoolActionDevices { get; set; }

        public List<BoolDeviceEventAction> EventActions { get; set; }
    }
}
