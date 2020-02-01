using System;
using System.Linq;
using SmartHome.Data.Models;

namespace SmartHome.Controller.Entities
{
    /// <summary>
    /// Логическое исполнительное устройство
    /// </summary>
    public class BoolActionDeviceEntity
    {
        public delegate void DeviceEventHandler(bool value);
        
        private bool _enabled;

        internal BoolActionDeviceEntity(BoolActionDevice device) => Device = device;


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
        /// Оригинальный объект устройства
        /// </summary>
        internal BoolActionDevice Device { get; }
    }
}
