using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class UserActionHistory : IUserActionHistory
    {
        public long ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IUser User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISmartCard SmartCard { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
