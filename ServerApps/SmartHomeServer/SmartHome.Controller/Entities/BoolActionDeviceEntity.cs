using System;
using System.Linq;
using SmartHome.Data.Interfaces.Models;
using SmartHome.Data.Store;

namespace SmartHome.Controller.Entities
{
    /// <summary>
    /// Логическое исполнительное устройство
    /// </summary>
    public class BoolActionDeviceEntity
    {
        public delegate void DeviceEventHandler(bool value);
        
        private bool _enabled;

        private BoolActionDeviceEntity(IBoolActionDevice device) => Device = device;


        /// <summary>
        /// Событие, возникающее при изменении состояния устройства
        /// </summary>
        public event DeviceEventHandler OnStateChanged;

        /// <summary>
        /// Системное имя устройства
        /// </summary>
        public string SysName => Device.SysName;

        /// <summary>
        /// Текущее требуемое состояние устройства (вкл/выкл)
        /// </summary>
        public bool Enabled
        {
            get => _enabled;
            internal set
            {
                _enabled = value;
                OnStateChanged?.Invoke(value);
            }
        }

        /// <summary>
        /// Привязать устройство к указанному контроллеру
        /// </summary>
        /// <param name="controller">контроллер, который должен управлять устройством</param>
        public void Bind(IDeviceController controller) => controller.Bind(this);

        /// <summary>
        /// Оригинальный объект устройства
        /// </summary>
        internal IBoolActionDevice Device { get; }


        /// <summary>
        /// Создание экземпляра устройства
        /// </summary>
        /// <param name="store"></param>
        /// <param name="deviceSysName"></param>
        /// <returns></returns>
        public static BoolActionDeviceEntity CreateEntity(IOperativeStore store, string deviceSysName)
        {
            if (store == null) throw new ArgumentNullException(nameof(IOperativeStore));
            if (string.IsNullOrWhiteSpace(deviceSysName))
                throw new ArgumentException("Wrong parameter", nameof(deviceSysName));

            IBoolActionDevice device;
            device = store.BoolActionDevices.Get(x => x.SysName == deviceSysName).FirstOrDefault();
            if (device == null) throw new NullReferenceException("Устройства не существует в текущей конфигурации");
            return new BoolActionDeviceEntity(device);
        }

    }
}
