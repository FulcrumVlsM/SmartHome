using System.Collections.Generic;

namespace SmartHome.Data.Models
{
    public class User
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public bool InHome { get; set; }
        

        public List<SmartCard> SmartCards { get; set; }

        public List<UserCondition> Conditions { get; set; }
    }
}
