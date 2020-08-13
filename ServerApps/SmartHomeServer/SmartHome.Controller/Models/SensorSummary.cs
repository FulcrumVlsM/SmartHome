using SmartHome.Data.Models;
using System.Collections.Generic;

namespace SmartHome.Controller.Models
{
    public class SensorSummary
    {
        public IEnumerable<NumericSensor> Sensors { get; set; }

        public IEnumerable<NumericSensorHistoryItem> History { get; set; }
    }
}
