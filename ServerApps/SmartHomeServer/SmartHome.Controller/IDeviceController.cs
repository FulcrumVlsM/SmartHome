using SmartHome.Controller.Entities;

namespace SmartHome.Controller
{
    /// <summary>
    /// Интерфейс контроллера умного дома
    /// </summary>
    public interface IDeviceController
    {
        BoolSensorEntity GetBoolSensor(string sysName);

        NumericSensorEntity GetNumericSensor(string sysName);

        BoolActionDeviceEntity GetBoolActionDevice(string sysName);

        EventDeviceEntity GetEventDevice(string sysName);

        void SetNewValue(BoolSensorEntity boolSensor, bool value);

        void SetNewValue(NumericSensorEntity numericSensor, float value);

        void HandleEvent(EventDeviceEntity eventDevice);
    }
}
