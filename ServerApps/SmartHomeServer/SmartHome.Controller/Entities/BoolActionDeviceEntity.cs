using SmartHome.Common.Enums;
using SmartHome.Data.Models;
using System;

namespace SmartHome.Controller.Entities
{
    public class BoolActionDeviceEntity
    {
        private readonly BoolActionDevice _device;
        
        public BoolActionDeviceEntity(BoolActionDevice device, bool value)
        {
            _device = device;
            _value = value;
        }


        public string SysName => _device.SysName;

        public DeviceStateMode DeviceStateMode => _device.ActivityMode;


        private bool _value;
        public bool Value
        {
            get => _value;
            internal set
            {
                _value = value;
                OnStateChanged?.Invoke(value);
            }
        }

        
        public event Action<bool> OnStateChanged;
    }
}
