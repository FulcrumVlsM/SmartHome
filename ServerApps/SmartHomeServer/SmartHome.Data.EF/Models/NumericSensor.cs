using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class NumericSensor : INumericSensor
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [MaxLength(1024)]
        public string SysName { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastActivity { get; set; }
        
        public bool ActivityMode { get; set; }
        
        public float Value { get; set; }


        public List<INumericSensorCondition> Conditions { get; set; }
    }
}
