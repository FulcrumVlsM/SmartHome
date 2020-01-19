using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class SmartCard : ISmartCard
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IUser User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
