using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class UserCondition : IUserCondition
    {
        public IRuleNode Node { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IUser User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
