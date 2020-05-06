using SmartHome.Controller.Values;
using System;
using System.Threading.Tasks;

namespace SmartHome.Controller
{
    public interface IDeviceController
    {
        bool PassValue(BoolSensorValue value);

        bool PassValue(NumericSensorValue value);

        bool ThrowEvent(DeviceEventWrapper deviceEvent);

        bool RegistryBoolActionDeviceHandler(string sysName, Func<bool, Task> eventHadler);


        Task Refresh();
    }
}
