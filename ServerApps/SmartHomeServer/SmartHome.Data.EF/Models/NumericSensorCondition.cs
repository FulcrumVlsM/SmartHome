using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class NumericSensorCondition : INumericSensorCondition
    {
        public IRuleNode Node { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public INumericSensor Sensor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ComparisonMode ComparisonMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
