using SmartHome.Data.Enums;
using System;

namespace SmartHome.Data.Interfaces
{
    public interface ITimeCondition
    {
        /// <summary>
        /// Идентификатор свзанного узла правила
        /// </summary>
        int NodeID { get; set; }

        /// <summary>
        /// Опорное значение
        /// </summary>
        TimeSpan Value { get; set; }

        /// <summary>
        /// Режим сравнения
        /// </summary>
        ComparisonMode ComparisonMode { get; set; }


        /// <summary>
        /// Связанный узел правила
        /// </summary>
        IRuleNode Node { get; set; }
    }
}
