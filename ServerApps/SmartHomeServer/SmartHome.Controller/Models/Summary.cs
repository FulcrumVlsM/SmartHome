using SmartHome.Data.Models;
using System.Collections.Generic;

namespace SmartHome.Controller.Models
{
    /// <summary>
    /// Текущая сводка
    /// </summary>
    public class Summary
    {
        /// <summary>
        /// Сводка температуры
        /// </summary>
        public SensorSummary TemperatureSummary { get; set; }

        /// <summary>
        /// Сводка влажности
        /// </summary>
        public SensorSummary HimiditySummary { get; set; }

        /// <summary>
        /// Сводка уровня CO2
        /// </summary>
        public SensorSummary DioxideSummary { get; set; }

        /// <summary>
        /// Активные устройства
        /// </summary>
        public IEnumerable<BoolActionDevice> ActiveDevices { get; set; }
    }
}
