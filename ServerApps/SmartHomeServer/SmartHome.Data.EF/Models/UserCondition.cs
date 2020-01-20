using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class UserCondition : IUserCondition
    {
        public RuleNode Node { get; set; }

        public User User { get; set; }

        public bool Value { get; set; }


        IRuleNode IUserCondition.Node { get => Node; set => throw new NotImplementedException(); }
        
        IUser IUserCondition.User { get => User; set => throw new NotImplementedException(); }
    }
}
