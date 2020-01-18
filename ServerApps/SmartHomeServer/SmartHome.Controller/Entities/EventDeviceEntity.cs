using System;
using System.Linq;
using SmartHome.Data.Interfaces.Models;
using SmartHome.Data.Store;

namespace SmartHome.Controller.Entities
{
    public class EventDeviceEntity
    {
        private readonly IEventDevice _device;
        private readonly IDeviceController _controller;

        private EventDeviceEntity(IEventDevice device, IDeviceController controller)
        {
            _device = device;
            _controller = controller;
        }


        /// <summary>
        /// Системное имя устройства
        /// </summary>
        public string SysName => _device.SysName;


        /// <summary>
        /// Сгенерировать событие
        /// </summary>
        public void CreateEvent() => _controller.HandleEvent(this);


        /// <summary>
        /// Создать экземпляр устройства
        /// </summary>
        /// <param name="store">Хранилище устройств</param>
        /// <param name="controller">Контроллер умного дома</param>
        /// <param name="deviceSysName">Системное имя устройства</param>
        /// <returns></returns>
        public static EventDeviceEntity CreateEntity(
            IOperativeStore store, 
            IDeviceController controller, 
            string deviceSysName)
        {
            if (store == null) throw new ArgumentNullException(nameof(store));
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            if (string.IsNullOrWhiteSpace(deviceSysName)) 
                throw new ArgumentException("Wrong parameter", nameof(deviceSysName));

            IEventDevice device = store.EventDevices.Get(x => x.SysName == deviceSysName).FirstOrDefault();
            if (device == null) throw new NullReferenceException("Устройства не существует в текущей конфигурации");
            return new EventDeviceEntity(device, controller);
        }
    }
}
