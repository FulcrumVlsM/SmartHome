using System;

namespace SmartHome.Data.Models
{
    public class NumericSensorHistory
    {
        public long ID { get; set; }

        public float Value { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public string SysName { get; set; }
    }
}
