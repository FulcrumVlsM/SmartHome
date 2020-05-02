using SmartHome.Common.Enums;
using SmartHome.Controller.Extensions;
using SmartHome.Data.Models;
using System;
using System.Threading.Tasks;

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
        public bool Value => _value;

        internal async Task SetValueAsync(bool value)
        {
            bool currentValue = DeviceStateMode.GetTargetValue(_value);
            bool newValue = DeviceStateMode.GetTargetValue(value);
            if (newValue != currentValue && OnStateChanged != null) await OnStateChanged(value);
            _value = value;
        }

        
        public event Func<bool,Task> OnStateChanged;
    }
}
