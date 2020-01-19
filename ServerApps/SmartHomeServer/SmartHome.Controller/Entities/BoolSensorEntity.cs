using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Controller.Entities
{
    /// <summary>
    /// Логический датчик
    /// </summary>
    public class BoolSensorEntity
    {
        private readonly IDeviceController _controller;

        internal BoolSensorEntity(IBoolSensor sensor, IDeviceController controller)
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
        public bool Value { set => _controller.SetNewValue(this, value); }

        /// <summary>
        /// Оригинальное устройство
        /// </summary>
        internal IBoolSensor Sensor { get; }
    }
}
