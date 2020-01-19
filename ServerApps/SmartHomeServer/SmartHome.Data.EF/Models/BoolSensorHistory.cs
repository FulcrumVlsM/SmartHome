using System;
using System.ComponentModel.DataAnnotations;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolSensorHistory : IBoolSensorHistory
    {
        [Key]
        public long ID { get; set; }
        
        [Required]
        public bool Value { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        [Required]
        public string SysName { get; set; }
    }
}
