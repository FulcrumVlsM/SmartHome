using SmartHome.Common.Enums;
using System;

namespace SmartHome.Data.Models
{
    public interface ITimeCondition
    {
        /// <summary>
        /// Связанный узел правила
        /// </summary>
        IRuleNode Node { get; set; }

        /// <summary>
        /// Опорное значение
        /// </summary>
        TimeSpan Value { get; set; }

        /// <summary>
        /// Режим сравнения
        /// </summary>
        ComparisonMode ComparisonMode { get; set; }
    }
}
