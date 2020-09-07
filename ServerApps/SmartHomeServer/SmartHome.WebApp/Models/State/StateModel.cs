using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartHome.WebApp.Models.State
{
    /// <summary>
    /// Модель состояния по основным показателям
    /// </summary>
    public class StateModel
    {
        /// <summary>
        /// Температура
        /// </summary>
        [JsonProperty(PropertyName = "TemperatureState")]
        public TemperatureStateModel TemperatureState { get; set; }

        /// <summary>
        /// Влажность воздуха
        /// </summary>
        [JsonProperty(PropertyName = "HumidityState")]
        public HimidityStateModel HumidityState { get; set; }

        /// <summary>
        /// Уровень CO2
        /// </summary>
        [JsonProperty(PropertyName = "DioxideState")]
        public DioxideStateModel DioxideState { get; set; }

        /// <summary>
        /// Активные устройства
        /// </summary>
        [JsonProperty(PropertyName = "ActiveDevices")]
        public List<BoolActionDeviceModel> ActiveDevices { get; set; }
    }
}
