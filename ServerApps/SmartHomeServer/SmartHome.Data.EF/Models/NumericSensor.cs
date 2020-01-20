using System;
using System.Collections.Generic;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class NumericSensor : INumericSensor
    {
        public int ID { get; set; }
        
        public string SysName { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastActivity { get; set; }
        
        public bool ActivityMode { get; set; }

        public DeviceCategory Category { get; set; }

        public float Value { get; set; }


        public List<NumericSensorCondition> Conditions { get; set; }


        List<INumericSensorCondition> INumericSensor.Conditions => Conditions.ConvertAll<INumericSensorCondition>(x => x);
    }
}
