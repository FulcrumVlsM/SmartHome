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
        int IBoolActionDevice.ID { get; set; }
        
        [Required]
        [MaxLength(1024)]
        string IBoolActionDevice.SysName { get; set; }
        
        [Required]
        string IBoolActionDevice.Name { get; set; }
        
        DeviceStateMode IBoolActionDevice.ActivityMode { get; set; }
        
        DateTime IBoolActionDevice.CreateDate { get; set; }
        
        DateTime IBoolActionDevice.LastActivityDate { get; set; }

        
        [NotMapped]
        List<IRule> IBoolActionDevice.Rules => Rules.ConvertAll<IRule>(x => x);

        [NotMapped]
        List<IBoolDeviceEventAction> IBoolActionDevice.EventActions => EventActions.ConvertAll<IBoolDeviceEventAction>(x => x);


        internal List<Rule> Rules { get; set; }

        internal List<BoolDeviceEventAction> EventActions { get; set; }
    }
}
