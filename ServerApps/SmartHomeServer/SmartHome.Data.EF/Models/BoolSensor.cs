using System;
using System.Collections.Generic;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolSensor : IBoolSensor
    {
        public int ID { get; set; }

        public string SysName { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastActivity { get; set; }

        public bool ActivityMode { get; set; }

        public DeviceCategory Category { get; set; }

        public bool Value { get; set; }


        public List<BoolSensorCondition> Conditions { get; set; }


        List<IBoolSensorCondition> IBoolSensor.Conditions => Conditions.ConvertAll<IBoolSensorCondition>(x => x);
    }
}
