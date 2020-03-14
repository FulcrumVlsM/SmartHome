using System;

namespace SmartHome.Controller.Values
{
    public class DeviceEventWrapper
    {
        public DeviceEventWrapper(string sensorName)
        {
            SensorName = sensorName;
            EventDate = DateTime.Now;
        }
        
        public string SensorName { get; set; }

        public DateTime EventDate { get; set; }
    }
}
