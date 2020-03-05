using SmartHome.Data.Models;

namespace SmartHome.Controller.Comparators
{
    internal class NumericEqualComparator : IComparator
    {
        private readonly NumericSensorCondition _condition;

        public NumericEqualComparator(NumericSensorCondition condition) => _condition = condition;


        public bool IsRight() => _condition.Sensor.Value == _condition.Value;
    }
}
