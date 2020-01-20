using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class SmartCard : ISmartCard
    {
        public int ID { get; set; }
        
        public string Key { get; set; }
        
        public string Name { get; set; }
        

        public User User { get; set; }


        IUser ISmartCard.User { get => User; set => throw new NotImplementedException(); }
    }
}
