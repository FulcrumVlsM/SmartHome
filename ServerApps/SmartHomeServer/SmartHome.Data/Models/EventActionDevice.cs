using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Data.Models
{
    public class EventActionDevice
    {
        public int ID { get; set; }

        public string SysName { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastActivityDate { get; set; }


        public ICollection<EventDevice2EventActionDevice> EventDevices2EventActionDevice { get; set; }
    }
}
