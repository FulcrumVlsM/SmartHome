using SmartHome.Data.Models;

namespace SmartHome.Controller.Comparators
{
    internal class NumericLessThanComparator : IComparator
    {
        private readonly NumericSensorCondition _condition;

        public NumericLessThanComparator(NumericSensorCondition condition) => _condition = condition;


        public bool IsRight() => _condition.Sensor.Value < _condition.Value;
    }
}
