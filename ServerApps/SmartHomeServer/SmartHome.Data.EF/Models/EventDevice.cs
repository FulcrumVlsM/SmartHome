using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
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

        
        public List<IRule> Conditions { get; set; }
        
        public List<IBoolDeviceEventAction> Actions { get; set; }
    }
}
