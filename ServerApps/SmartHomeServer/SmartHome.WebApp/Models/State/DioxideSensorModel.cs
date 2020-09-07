using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "SysName")]
        public string SysName { get; set; }

        /// <summary>
        /// Наименование датчика
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Текущее значение
        /// </summary>
        [JsonProperty(PropertyName = "Value")]
        public float Value { get; set; }
    }
}
