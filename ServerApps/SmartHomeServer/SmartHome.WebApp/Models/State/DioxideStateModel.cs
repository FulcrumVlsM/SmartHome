using System.Collections.Generic;
using System.Linq;

namespace SmartHome.WebApp.Models.State
{
    public class DioxideStateModel
    {
        public float Average => Sensors != null && Sensors.Count > 0 ? Sensors.Average(sensor => sensor.Value) : 0;

        public List<DioxideSensorModel> Sensors { get; set; }
    }
}
