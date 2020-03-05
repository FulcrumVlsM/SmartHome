using SmartHome.Data.Models;
using System;

namespace SmartHome.Controller.Comparators
{
    internal class TimeNotEqualComparator : IComparator
    {
        private readonly TimeCondition _condition;

        public TimeNotEqualComparator(TimeCondition condition) => _condition = condition;
        

        public bool IsRight()
        {
            var timeNow = DateTime.Now - DateTime.Now.Date;
            var requiredTime = _condition.Value;
            return requiredTime.TotalMinutes != timeNow.TotalMinutes;
        }
    }
}
