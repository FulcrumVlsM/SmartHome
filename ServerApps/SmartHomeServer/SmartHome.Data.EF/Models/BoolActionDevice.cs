using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolActionDevice : IBoolActionDevice
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [MaxLength(1024)]
        public string SysName { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public DeviceStateMode ActivityMode { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastActivityDate { get; set; }

        public DeviceCategory Category { get; set; }


        List<IRule> IBoolActionDevice.Rules => Rules.ConvertAll<IRule>(x => x);

        List<IBoolDeviceEventAction> IBoolActionDevice.EventActions => EventActions.ConvertAll<IBoolDeviceEventAction>(x => x);


        public List<Rule> Rules { get; set; }

        public List<BoolDeviceEventAction> EventActions { get; set; }
    }
}
