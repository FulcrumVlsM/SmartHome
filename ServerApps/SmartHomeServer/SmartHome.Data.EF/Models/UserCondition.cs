using System;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class UserCondition : IUserCondition
    {
        public int RuleNodeID { get; set; }
        public RuleNode Node { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public bool Value { get; set; }


        IRuleNode IUserCondition.Node { get => Node; set => throw new NotImplementedException(); }
        
        IUser IUserCondition.User { get => User; set => throw new NotImplementedException(); }
    }
}
