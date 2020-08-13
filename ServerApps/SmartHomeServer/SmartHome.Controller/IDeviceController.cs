using SmartHome.Controller.Values;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHome.Controller
{
    public interface IDeviceController
    {
        bool PassValue(BoolSensorValue value);

        bool PassValue(NumericSensorValue value);

        Task<bool> ThrowEvent(DeviceEventWrapper deviceEvent);

        bool RegistryBoolActionDeviceHandler(string sysName, Func<bool, Task> eventHadler);

        bool RegistryEventActionDeviceHandler(string sysName, Func<Task> eventHandler);

        IEnumerable<string> GetActiveBoolActionDeviceNames();


        Task Refresh();
    }
}
