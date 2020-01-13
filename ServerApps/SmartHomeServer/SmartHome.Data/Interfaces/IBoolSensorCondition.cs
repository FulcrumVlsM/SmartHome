namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий условие соответствия для логического датчика
    /// </summary>
    public interface IBoolSensorCondition
    {
        /// <summary>
        /// Связанный узел правила
        /// </summary>
        IRuleNode Node { get; set; }

        /// <summary>
        /// Связанный датчик
        /// </summary>
        IBoolSensor Sensor { get; set; }

        /// <summary>
        /// Требуемое значение
        /// </summary>
        bool RequiredValue { get; set; }
    }
}
