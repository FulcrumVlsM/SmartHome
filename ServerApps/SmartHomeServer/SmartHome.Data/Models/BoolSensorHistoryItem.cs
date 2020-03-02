using System;

namespace SmartHome.Data.Models
{
    public class BoolSensorHistoryItem
    {
        public long ID { get; set; }
        
        public bool Value { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public string SysName { get; set; }
    }
}
