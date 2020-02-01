using System.Collections.Generic;

namespace SmartHome.Data.Models
{
    public class User
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public bool InHome { get; set; }

        public bool Enable { get; set; }
        

        public ICollection<SmartCard> SmartCards { get; set; }

        public ICollection<UserCondition> Conditions { get; set; }

        public ICollection<UserActionHistory> History { get; set; }
    }
}
