﻿using SmartHome.Data.Models;
using System;

namespace SmartHome.Controller.Comparators
{
    internal class TimeEqualComparator : IComparator
    {
        private readonly TimeCondition _condition;

        public TimeEqualComparator(TimeCondition condition) => _condition = condition;


        public bool IsRight()
        {
            var timeNow = DateTime.Now - DateTime.Now.Date;
            var requiredTime = _condition.Value;
            return requiredTime.TotalMinutes == timeNow.TotalMinutes;
        }
    }
}
