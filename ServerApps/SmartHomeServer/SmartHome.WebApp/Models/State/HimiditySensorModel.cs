using Newtonsoft.Json;

namespace SmartHome.WebApp.Models.State
{
    /// <summary>
    /// Модель датчика влажности
    /// </summary>
    public class HimiditySensorModel
    {
        /// <summary>
        /// Системное наименование
        /// </summary>
        [JsonProperty(PropertyName = "SysName")]
        public string SysName { get; set; }

        /// <summary>
        /// Наименование датчика
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Актуальное значение, полученное с датчика
        /// </summary>
        [JsonProperty(PropertyName = "Value")]
        public float Value { get; set; }
    }
}
