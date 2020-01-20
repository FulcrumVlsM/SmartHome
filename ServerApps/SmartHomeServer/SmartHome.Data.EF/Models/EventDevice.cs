using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class EventDevice : IEventDevice
    {
        public int ID { get; set; }

        public string Name { get; set; }
        
        public string SysName { get; set; }

        public bool Enable { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastEventDate { get; set; }

        public DeviceCategory Category { get; set; }


        public List<Rule2EventDevice> Rule2EventDevices { get; set; }

        public List<BoolDeviceEventAction> Actions { get; set; }


        List<IRule2EventDevice> IEventDevice.Rule2EventDevices => Rule2EventDevices
            .ConvertAll<IRule2EventDevice>(x => x);

        List<IBoolDeviceEventAction> IEventDevice.Actions => Actions.ConvertAll<IBoolDeviceEventAction>(x => x);
    }
}
