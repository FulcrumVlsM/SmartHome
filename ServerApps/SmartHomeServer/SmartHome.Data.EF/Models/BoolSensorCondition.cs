using System;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolSensorCondition : IBoolSensorCondition
    {
        public RuleNode Node { get; set; }

        public BoolSensor Sensor { get; set; }

        public bool RequiredValue { get; set; }


        IRuleNode IBoolSensorCondition.Node { get => Node; set => throw new NotImplementedException(); }
        
        IBoolSensor IBoolSensorCondition.Sensor { get => Sensor; set => throw new NotImplementedException(); }
    }
}
