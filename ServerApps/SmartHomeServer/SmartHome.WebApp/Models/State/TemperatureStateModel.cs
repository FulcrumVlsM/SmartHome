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
        public float Avg => Sensors.Average(sensor => sensor.Value);

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
