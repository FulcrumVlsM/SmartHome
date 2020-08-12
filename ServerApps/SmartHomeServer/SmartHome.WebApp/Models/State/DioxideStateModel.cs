using System.Collections.Generic;
using System.Linq;

namespace SmartHome.WebApp.Models.State
{
    public class DioxideStateModel
    {
        public float Average => Sensors.Average(sensor => sensor.Value);

        public List<DioxideSensorModel> Sensors { get; set; }
    }
}
