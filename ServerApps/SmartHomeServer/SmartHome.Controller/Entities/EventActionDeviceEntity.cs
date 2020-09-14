using SmartHome.Data.Models;
using System;
using System.Threading.Tasks;

namespace SmartHome.Controller.Entities
{
    public class EventActionDeviceEntity
    {
        private readonly EventActionDevice _device;

        public EventActionDeviceEntity(EventActionDevice device)
        {
            _device = device;
        }


        public string SysName => _device.SysName;

        internal async Task CallAsync()
        {
            if (OnCallDevice != null) await OnCallDevice();
        }


        public event Func<Task> OnCallDevice;
    }
}
