using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolSensor : IBoolSensor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(1024)]
        public string SysName { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastActivity { get; set; }

        public bool ActivityMode { get; set; }

        public DeviceCategory Category { get; set; }

        public bool Value { get; set; }


        [NotMapped]
        List<IBoolSensorCondition> IBoolSensor.Conditions => Conditions.ConvertAll<IBoolSensorCondition>(x => x);


        public List<BoolSensorCondition> Conditions { get; set; }
    }
}
