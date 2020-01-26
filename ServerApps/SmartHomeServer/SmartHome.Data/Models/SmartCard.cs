using System;

namespace SmartHome.Data.Models
{
    public class SmartCard
    {
        public int ID { get; set; }
        
        public string Key { get; set; }
        
        public string Name { get; set; }
        

        public User User { get; set; }
    }
}
