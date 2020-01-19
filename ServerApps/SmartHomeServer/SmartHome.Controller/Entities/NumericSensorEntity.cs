using System;
using System.Linq;
using SmartHome.Data.Interfaces.Models;
using SmartHome.Data.Store;

namespace SmartHome.Controller.Entities
{
    /// <summary>
    /// Измерительный датчик
    /// </summary>
    public class NumericSensorEntity
    {
        private readonly IDeviceController _controller;
        
        internal NumericSensorEntity(INumericSensor sensor, IDeviceController controller)
        {
            Sensor = sensor;
            _controller = controller;
        }


        /// <summary>
        /// Системное имя устройства
        /// </summary>
        public string SysName => Sensor.SysName;

        /// <summary>
        /// Установить новое значение
        /// </summary>
        public float Value { set => _controller.SetNewValue(this, value); }

        /// <summary>
        /// Оригинальное устройство
        /// </summary>
        internal INumericSensor Sensor { get; }
    }
}
