﻿namespace SmartHome.Data.Models
{
    public class UserActionHistoryItem
    {
        public long ID { get; set; }

        public bool Value { get; set; }


        public int UserID { get; set; }
        public User User { get; set; }
    }
}
