using SmartHome.Common.Enums;
using SmartHome.Controller.Comparators;
using SmartHome.Data.Models;
using System;

namespace SmartHome.Controller.Extensions
{
    internal static class ComparisonModeExtensions
    {
        internal static IComparator GetComparator(this ComparisonMode comparisonMode, NumericSensorCondition condition)
        {
            switch (comparisonMode)
            {
                case ComparisonMode.NotEqual: return new NumericNotEqualComparator(condition);
                case ComparisonMode.Equal: return new NumericEqualComparator(condition);
                case ComparisonMode.LessThanOrEqual: return new NumericLessThenEqualComparator(condition);
                case ComparisonMode.MoreOrEqual: return new NumericMoreOrEqualComparator(condition);
                case ComparisonMode.More: return new NumericMoreComparator(condition);
                case ComparisonMode.LessThan: return new NumericLessThanComparator(condition);
                default: throw new InvalidOperationException($"Недопустимое значение перечислителя ComparisonMode: {(int)comparisonMode}");
            }
        }


        internal static IComparator GetComparator(this ComparisonMode comparisonMode, TimeCondition condition)
        {
            switch (comparisonMode)
            {
                case ComparisonMode.NotEqual: return new TimeNotEqualComparator(condition);
                case ComparisonMode.Equal: return new TimeEqualComparator(condition);
                case ComparisonMode.LessThanOrEqual: return new TimeLessThanOrEqualComparator(condition);
                case ComparisonMode.MoreOrEqual: return new TimeMoreOrEqualComparator(condition);
                case ComparisonMode.More: return new TimeMoreCondition(condition);
                case ComparisonMode.LessThan: return new TimeLessThanComparator(condition);
                default: throw new InvalidOperationException($"Недопустимое значение перечислителя ComparisonMode: {(int)comparisonMode}");
            }
        }
    }
}
