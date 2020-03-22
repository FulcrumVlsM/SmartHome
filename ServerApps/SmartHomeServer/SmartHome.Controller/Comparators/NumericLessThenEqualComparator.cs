using SmartHome.Data.Models;

namespace SmartHome.Controller.Comparators
{
    internal class NumericLessThenEqualComparator : IComparator
    {
        private readonly NumericSensorCondition _condition;

        public NumericLessThenEqualComparator(NumericSensorCondition condition) => _condition = condition;

        public bool IsRight() => _condition.Sensor.Value <= _condition.Value;
    }
}
