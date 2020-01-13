using System.Collections.Generic;

namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс элемента условия правила для исполнительных устройств. 
    /// Между всеми элементами действует логическое И.
    /// </summary>
    public interface IRuleNode
    {
        /// <summary>
        /// Правило, к которому относится узел
        /// </summary>
        IRule Rule { get; set; }

        /// <summary>
        /// Условия для логических датчиков
        /// </summary>
        List<IBoolSensorCondition> BoolSensorConditions { get; set; }

        /// <summary>
        /// Условия для числовых датчиков
        /// </summary>
        List<INumericSensorCondition> NumericSensorConditions { get; set; }

        /// <summary>
        /// Условия времени суток
        /// </summary>
        List<ITimeCondition> TimeConditions { get; set; }
    }
}
