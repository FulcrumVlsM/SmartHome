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
        public float Average => Sensors.Average(sensor => sensor.Value);

        /// <summary>
        /// Коллекция активных датчиков
        /// </summary>
        public List<HimiditySensorModel> Sensors { get; set; }
    }
}
