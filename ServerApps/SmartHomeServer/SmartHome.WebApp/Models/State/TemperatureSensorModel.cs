using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "SysName")]
        public string SysName { get; set; }

        /// <summary>
        /// Пользовательское наименование датчика
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Актуальное значение
        /// </summary>
        [JsonProperty(PropertyName = "Value")]
        public float Value { get; set; }
    }
}
