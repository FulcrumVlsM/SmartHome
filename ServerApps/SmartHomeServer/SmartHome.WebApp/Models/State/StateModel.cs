﻿namespace SmartHome.WebApp.Models.State
{
    /// <summary>
    /// Модель состояния по основным показателям
    /// </summary>
    public class StateModel
    {
        /// <summary>
        /// Температура
        /// </summary>
        public TemperatureStateModel TemperatureState { get; set; }

        /// <summary>
        /// Влажность воздуха
        /// </summary>
        public HimidityStateModel HimidityState { get; set; }
        
        /// <summary>
        /// Уровень CO2
        /// </summary>
        public DioxideStateModel DioxideState { get; set; }

        //Коллекция с устройствами с текущим состоянием (только активные)
    }
}
