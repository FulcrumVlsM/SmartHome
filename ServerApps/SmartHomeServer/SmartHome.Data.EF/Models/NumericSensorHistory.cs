using System;
using System.ComponentModel.DataAnnotations;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class NumericSensorHistory : INumericSensorHistory
    {
        [Key]
        public long ID { get; set; }
        
        [Required]
        public float Value { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        [Required]
        public string SysName { get; set; }
    }
}
