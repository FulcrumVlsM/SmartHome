using System;
using System.Collections.Generic;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolActionDevice : IBoolActionDevice
    {
        public int ID { get; set; }
        
        public string SysName { get; set; }
        
        public string Name { get; set; }
        
        public DeviceStateMode ActivityMode { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastActivityDate { get; set; }

        public DeviceCategory Category { get; set; }


        List<IRule2BoolActionDevice> IBoolActionDevice.Rule2BoolActionDevices => Rule2BoolActionDevices
            .ConvertAll<IRule2BoolActionDevice>(x => x);

        List<IBoolDeviceEventAction> IBoolActionDevice.EventActions => EventActions.ConvertAll<IBoolDeviceEventAction>(x => x);


        public List<Rule2BoolActionDevice> Rule2BoolActionDevices { get; set; }

        public List<BoolDeviceEventAction> EventActions { get; set; }
    }
}
