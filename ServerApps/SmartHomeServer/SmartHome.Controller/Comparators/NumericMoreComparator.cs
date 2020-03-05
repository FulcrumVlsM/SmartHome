using SmartHome.Data.Models;

namespace SmartHome.Controller.Comparators
{
    internal class NumericMoreComparator : IComparator
    {
        private readonly NumericSensorCondition _condition;

        public NumericMoreComparator(NumericSensorCondition condition) => _condition = condition;


        public bool IsRight() => _condition.Sensor.Value > _condition.Value;
    }
}
