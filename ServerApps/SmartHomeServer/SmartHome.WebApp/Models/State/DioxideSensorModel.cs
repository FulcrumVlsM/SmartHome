namespace SmartHome.WebApp.Models.State
{
    /// <summary>
    /// Модель состояния датчика уровня CO2
    /// </summary>
    public class DioxideSensorModel
    {
        /// <summary>
        /// Системное имя датчика
        /// </summary>
        public string SysName { get; set; }

        /// <summary>
        /// Наименование датчика
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Текущее значение
        /// </summary>
        public float Value { get; set; }
    }
}
