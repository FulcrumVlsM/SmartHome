using System;

namespace SmartHome.Data.Interfaces.Models
{
    public interface INumericSensorHistory
    {
        int ID { get; set; }

        float Value { get; set; }

        DateTime CreateDate { get; set; }

        INumericSensor Sensor { get; set; }
    }
}
