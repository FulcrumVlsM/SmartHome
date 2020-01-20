using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class NumericSensorCondition : INumericSensorCondition
    {
        IRuleNode INumericSensorCondition.Node { get => Node; set => throw new NotImplementedException(); }
        
        INumericSensor INumericSensorCondition.Sensor { get => Sensor; set => throw new NotImplementedException(); }
        
        public float Value { get; set; }
        
        public ComparisonMode ComparisonMode { get; set; }


        public RuleNode Node { get; set; }

        public NumericSensor Sensor { get; set; }
    }
}
