using SmartHome.Data.Models;

namespace SmartHome.Controller.Comparators
{
    internal class NumericMoreOrEqualComparator : IComparator
    {
        private readonly NumericSensorCondition _condition;

        public NumericMoreOrEqualComparator(NumericSensorCondition condition) => _condition = condition;


        public bool IsRight() => _condition.Sensor.Value >= _condition.Value;
    }
}
