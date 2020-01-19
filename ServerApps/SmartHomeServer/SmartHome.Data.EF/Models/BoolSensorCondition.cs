using System;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolSensorCondition : IBoolSensorCondition
    {
        internal RuleNode Node { get; set; }

        internal BoolSensor Sensor { get; set; }

        bool IBoolSensorCondition.RequiredValue { get; set; }


        [NotMapped]
        IRuleNode IBoolSensorCondition.Node { get => Node; set => throw new NotImplementedException(); }
        
        [NotMapped]
        IBoolSensor IBoolSensorCondition.Sensor { get => Sensor; set => throw new NotImplementedException(); }
    }
}
