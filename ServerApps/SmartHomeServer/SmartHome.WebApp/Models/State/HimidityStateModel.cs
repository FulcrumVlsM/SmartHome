using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome.WebApp.Models.State
{
    /// <summary>
    /// Модель для хранения текущего состояния по датчикам влажности
    /// </summary>
    public class HimidityStateModel
    {
        /// <summary>
        /// Среднее значение влажности
        /// </summary>
        [JsonProperty(PropertyName = "Average")]
        public float Average => Sensors != null && Sensors.Count > 0 ? Sensors.Average(sensor => sensor.Value) : 0;

        /// <summary>
        /// Коллекция активных датчиков
        /// </summary>
        [JsonProperty(PropertyName = "Sensors")]
        public List<HimiditySensorModel> Sensors { get; set; }
    }
}
