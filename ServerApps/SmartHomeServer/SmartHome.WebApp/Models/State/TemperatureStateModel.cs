using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome.WebApp.Models.State
{
    /// <summary>
    /// Модель состояния температуры
    /// </summary>
    public class TemperatureStateModel
    {
        /// <summary>
        /// Текущая средняя температура
        /// </summary>
        public float Average => Sensors != null && Sensors.Count > 0 ? Sensors.Average(sensor => sensor.Value) : 0;

        /// <summary>
        /// Активные датчики
        /// </summary>
        public List<TemperatureSensorModel> Sensors { get; set; }

        /// <summary>
        /// История за диапазон времени
        /// </summary>
        public Dictionary<DateTime, float> History { get; set; }
    }
}
