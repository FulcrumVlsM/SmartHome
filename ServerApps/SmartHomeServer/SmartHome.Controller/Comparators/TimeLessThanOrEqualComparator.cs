using SmartHome.Data.Models;
using System;

namespace SmartHome.Controller.Comparators
{
    internal class TimeLessThanOrEqualComparator : IComparator
    {
        private readonly TimeCondition _condition;

        public TimeLessThanOrEqualComparator(TimeCondition condition) => _condition = condition;


        public bool IsRight()
        {
            var timeNow = DateTime.Now - DateTime.Now.Date;
            var requiredTime = _condition.Value;
            return requiredTime.TotalMinutes <= timeNow.TotalMinutes;
        }
    }
}
