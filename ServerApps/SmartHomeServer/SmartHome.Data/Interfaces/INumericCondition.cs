using SmartHome.Data.Enums;

namespace SmartHome.Data.Interfaces
{
    public interface INumericCondition
    {
        /// <summary>
        /// Идентификатор связанного узла правила
        /// </summary>
        int NodeID { get; set; }

        /// <summary>
        /// Идентификатор связанного датчика
        /// </summary>
        int NumericSensorID { get; set; }

        /// <summary>
        /// Опорное значение
        /// </summary>
        float Value { get; set; }

        /// <summary>
        /// Режим сравнения
        /// </summary>
        ComparisonMode ComparisonMode { get; set; }


        /// <summary>
        /// Связанный узел правила
        /// </summary>
        IRuleNode Node { get; set; }

        /// <summary>
        /// Связанный датчик
        /// </summary>
        INumericSensor Sensor { get; set; }
    }
}
