using SmartHome.Data.Models;
using SmartHome.Controller.Extensions;
using System;

namespace SmartHome.Controller.Comparators
{
    internal class NumericSensorConditionComparator : IComparator
    {
        private readonly NumericSensorCondition _condition;

        public NumericSensorConditionComparator(NumericSensorCondition condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));
            _condition = condition;
        }


        public bool IsRight() => _condition.ComparisonMode.GetComparator(_condition).IsRight();
    }
}
