using System;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class UserActionHistory : IUserActionHistory
    {
        public long ID { get; set; }

        public bool Value { get; set; }


        public int UserID { get; set; }
        public User User { get; set; }

        public int SmartCardID { get; set; }
        public SmartCard SmartCard { get; set; }


        IUser IUserActionHistory.User { get => User; set => throw new NotImplementedException(); }
        
        ISmartCard IUserActionHistory.SmartCard { get => SmartCard; set => throw new NotImplementedException(); }
    }
}
