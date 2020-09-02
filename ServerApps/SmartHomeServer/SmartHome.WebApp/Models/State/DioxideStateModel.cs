using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome.WebApp.Models.State
{
    /// <summary>
    /// Модель для хранения ткушего состояния по датчикоам CO2
    /// </summary>
    public class DioxideStateModel
    {
        /// <summary>
        /// Среднее значение CO2
        /// </summary>
        [JsonProperty(PropertyName = "Average")]
        public float Average => Sensors != null && Sensors.Count > 0 ? Sensors.Average(sensor => sensor.Value) : 0;

        /// <summary>
        /// Список датчиков
        /// </summary>
        [JsonProperty(PropertyName = "Sensors")]
        public List<DioxideSensorModel> Sensors { get; set; }
    }
}
