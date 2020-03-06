using SmartHome.Data.Models;
using SmartHome.Controller.Extensions;

namespace SmartHome.Controller.Comparators
{
    internal class TimeConditionComparator : IComparator
    {
        private readonly TimeCondition _condition;

        public TimeConditionComparator(TimeCondition condition) => _condition = condition;


        public bool IsRight() => _condition.ComparisonMode.GetComparator(_condition).IsRight();
    }
}
