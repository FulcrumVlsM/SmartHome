using SmartHome.Data.Models;

namespace SmartHome.Controller.Comparators
{
    internal class NumericNotEqualComparator : IComparator
    {
        private readonly NumericSensorCondition _condition;

        public NumericNotEqualComparator(NumericSensorCondition condition) => _condition = condition;

        public bool IsRight() => _condition.Sensor.Value != _condition.Value;
    }
}
