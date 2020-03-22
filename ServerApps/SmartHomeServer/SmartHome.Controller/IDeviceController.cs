using SmartHome.Controller.Values;
using System;

namespace SmartHome.Controller
{
    public interface IDeviceController
    {
        bool PassValue(BoolSensorValue value);

        bool PassValue(NumericSensorValue value);

        bool ThrowEvent(DeviceEventWrapper deviceEvent);

        bool RegistryBoolActionDeviceHandler(string sysName, Action<bool> eventHadler);


        void Refresh();
    }
}
