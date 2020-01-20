using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartHome.Common.Enums;
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

        public DeviceCategory Category { get; set; }

        public float Value { get; set; }


        List<INumericSensorCondition> INumericSensor.Conditions => Conditions.ConvertAll<INumericSensorCondition>(x => x);

        public List<NumericSensorCondition> Conditions { get; set; }
    }
}
