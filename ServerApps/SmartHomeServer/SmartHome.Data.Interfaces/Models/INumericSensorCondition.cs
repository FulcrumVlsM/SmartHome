using SmartHome.Common.Enums;

namespace SmartHome.Data.Interfaces.Models
{
    public interface INumericSensorCondition
    {
        /// <summary>
        /// Связанный узел правила
        /// </summary>
        IRuleNode Node { get; set; }

        /// <summary>
        /// Связанный датчик
        /// </summary>
        INumericSensor Sensor { get; set; }

        /// <summary>
        /// Опорное значение
        /// </summary>
        float Value { get; set; }

        /// <summary>
        /// Режим сравнения
        /// </summary>
        ComparisonMode ComparisonMode { get; set; }
    }
}
