using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolSensor : IBoolSensor
    {
        [Key]
        int IBoolSensor.ID { get; set; }

        [Required]
        [MaxLength(1024)]
        string IBoolSensor.SysName { get; set; }

        [Required]
        string IBoolSensor.Name { get; set; }

        DateTime IBoolSensor.CreateDate { get; set; }

        DateTime IBoolSensor.LastActivity { get; set; }

        bool IBoolSensor.ActivityMode { get; set; }

        bool IBoolSensor.Value { get; set; }


        [NotMapped]
        List<IBoolSensorCondition> IBoolSensor.Conditions => Conditions.ConvertAll<IBoolSensorCondition>(x => x);


        internal List<BoolSensorCondition> Conditions { get; set; }
    }
}
