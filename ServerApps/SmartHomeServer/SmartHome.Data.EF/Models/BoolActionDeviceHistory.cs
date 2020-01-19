using System;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolActionDeviceHistory : IBoolActionDeviceHistory
    {
        public long ID { get; set; }
        
        public bool Value { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public string SysName { get; set; }
    }
}
