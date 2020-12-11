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
            Value = value;
        }


        public string SysName => _device.SysName;

        public DeviceStateMode DeviceStateMode => _device.ActivityMode;

        public bool Value { get; private set; }

        internal async Task SetValueAsync(bool value)
        {
            bool currentValue = DeviceStateMode.GetTargetValue(Value);
            bool newValue = DeviceStateMode.GetTargetValue(value);
            if (newValue != currentValue && OnStateChanged != null) await OnStateChanged(SysName, value);
            Value = value;
        }

        
        public event Func<string,bool,Task> OnStateChanged;
    }
}
