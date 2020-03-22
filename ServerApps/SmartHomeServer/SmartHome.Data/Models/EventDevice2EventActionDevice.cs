using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Data.Models
{
    public class EventDevice2EventActionDevice
    {
        public int EventDeviceID { get; set; }

        public EventDevice EventDevice { get; set; }


        public int EventActionDeviceID { get; set; }

        public EventActionDevice EventActionDevice { get; set; }
    }
}
