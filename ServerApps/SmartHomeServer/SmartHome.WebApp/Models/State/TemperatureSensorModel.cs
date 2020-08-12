namespace SmartHome.WebApp.Models.State
{
    /// <summary>
    /// Модель датчика температуры
    /// </summary>
    public class TemperatureSensorModel
    {
        /// <summary>
        /// Системное наименование датчика
        /// </summary>
        public string SysName { get; set; }

        /// <summary>
        /// Пользовательское наименование датчика
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Актуальное значение
        /// </summary>
        public float Value { get; set; }
    }
}
