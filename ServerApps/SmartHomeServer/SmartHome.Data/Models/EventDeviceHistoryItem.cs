﻿using System;

namespace SmartHome.Data.Models
{
    public class EventDeviceHistoryItem
    {
        public long ID { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public string SysName { get; set; }
    }
}
