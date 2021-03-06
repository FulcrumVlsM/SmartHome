﻿using System;
using System.Collections.Generic;
using SmartHome.Common.Enums;

namespace SmartHome.Data.Models
{
    public class NumericSensor
    {
        public int ID { get; set; }
        
        public string SysName { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastActivity { get; set; }
        
        public bool ActivityMode { get; set; }

        public DeviceCategory Category { get; set; }

        public float Value { get; set; }


        public ICollection<NumericSensorCondition> Conditions { get; set; }
    }
}
