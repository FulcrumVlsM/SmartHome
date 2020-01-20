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
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(1024)]
        public string SysName { get; set; }

        public bool Enable { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastEventDate { get; set; }

        public DeviceCategory Category { get; set; }


        List<IRule> IEventDevice.Conditions => Conditions.ConvertAll<IRule>(x => x);

        List<IBoolDeviceEventAction> IEventDevice.Actions => Actions.ConvertAll<IBoolDeviceEventAction>(x => x);


        public List<Rule> Conditions { get; set; }

        public List<BoolDeviceEventAction> Actions { get; set; }
    }
}
