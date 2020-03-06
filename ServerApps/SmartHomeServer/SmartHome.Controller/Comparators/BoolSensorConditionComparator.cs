using SmartHome.Data.Models;
using System;

namespace SmartHome.Controller.Comparators
{
    internal class BoolSensorConditionComparator : IComparator
    {
        private readonly BoolSensorCondition _condition;

        public BoolSensorConditionComparator(BoolSensorCondition condition) => _condition = condition ?? throw new ArgumentNullException(nameof(condition));


        public bool IsRight() => _condition.Sensor.Value == _condition.RequiredValue;
    }
}
