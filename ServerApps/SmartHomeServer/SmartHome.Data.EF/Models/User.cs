using System.Collections.Generic;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class User : IUser
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public bool InHome { get; set; }
        

        public List<SmartCard> SmartCards { get; set; }

        public List<UserCondition> Conditions { get; set; }


        List<ISmartCard> IUser.SmartCards => SmartCards.ConvertAll<ISmartCard>(x => x);

        List<IUserCondition> IUser.Conditions => Conditions.ConvertAll<IUserCondition>(x => x);
    }
}
