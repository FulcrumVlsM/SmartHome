using System;

namespace SmartHome.Data.Models
{
    public interface IBoolSensorHistory
    {
        int ID { get; set; }

        bool Value { get; set; }

        DateTime CreateDate { get; set; }

        IBoolSensor Sensor { get; set; }
    }
}
