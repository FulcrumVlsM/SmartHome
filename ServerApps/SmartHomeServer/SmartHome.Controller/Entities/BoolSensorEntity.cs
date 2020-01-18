using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHome.Data.Interfaces.Models;
using SmartHome.Data.Store;

namespace SmartHome.Controller.Entities
{
    /// <summary>
    /// Логический датчик
    /// </summary>
    public class BoolSensorEntity
    {
        private readonly IDeviceController _controller;

        private BoolSensorEntity(IBoolSensor sensor, IDeviceController controller)
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


        /// <summary>
        /// Возвращает объект сущности, связанный с указанным датчиком
        /// </summary>
        /// <param name="store">Хранилище текущей конфигурации</param>
        /// <param name="sensorSysName">Системное имя датчика</param>
        /// <returns></returns>
        public static BoolSensorEntity CreateEntity(IOperativeStore store, IDeviceController controller, string sensorSysName)
        {
            if (store == null) throw new ArgumentNullException(nameof(store));
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            if (string.IsNullOrWhiteSpace(sensorSysName)) 
                throw new ArgumentException("Wrong parameter", nameof(sensorSysName));
            
            IBoolSensor sensor;
            sensor = store.BoolSensors.Get(x => x.SysName == sensorSysName).FirstOrDefault();
            if (sensor == null) throw new InvalidOperationException("Устройство не найдено");
            return new BoolSensorEntity(sensor, controller);
        }
    }
}
