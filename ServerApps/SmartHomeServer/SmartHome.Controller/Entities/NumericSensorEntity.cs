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
        
        private NumericSensorEntity(INumericSensor sensor, IDeviceController controller)
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



        /// <summary>
        /// Возвращает объект сущности, связанный с указанным датчиком
        /// </summary>
        /// <param name="store"></param>
        /// <param name="sensorSysName"></param>
        /// <returns></returns>
        public NumericSensorEntity CreateEntity(IOperativeStore store, IDeviceController controller, string sensorSysName)
        {
            if (store == null) throw new ArgumentNullException(nameof(store));
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            if (string.IsNullOrWhiteSpace(sensorSysName))
                throw new ArgumentException("Wrong parameter", nameof(sensorSysName));

            INumericSensor sensor;
            sensor = store.NumericSensors.Get(x => x.SysName == sensorSysName).FirstOrDefault();
            if (sensor == null) throw new InvalidOperationException("Устройства не существует в текущей конфигурации");
            return new NumericSensorEntity(sensor, controller);
        }
    }
}
