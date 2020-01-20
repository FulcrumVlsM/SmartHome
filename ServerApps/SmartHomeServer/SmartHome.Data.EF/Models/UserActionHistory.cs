using System;
using System.ComponentModel.DataAnnotations;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class UserActionHistory : IUserActionHistory
    {
        [Key]
        public long ID { get; set; }
        
        [Required]
        public bool Value { get; set; }
        

        public User User { get; set; }

        public SmartCard SmartCard { get; set; }


        IUser IUserActionHistory.User { get => User; set => throw new NotImplementedException(); }
        
        ISmartCard IUserActionHistory.SmartCard { get => SmartCard; set => throw new NotImplementedException(); }
    }
}
