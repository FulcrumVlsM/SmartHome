using System.Collections.Generic;

namespace SmartHome.Data.Interfaces.Models
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
        List<IBoolSensorCondition> BoolSensorConditions { get; }

        /// <summary>
        /// Условия для числовых датчиков
        /// </summary>
        List<INumericSensorCondition> NumericSensorConditions { get; }

        /// <summary>
        /// Условия времени суток
        /// </summary>
        List<ITimeCondition> TimeConditions { get; }
    }
}
