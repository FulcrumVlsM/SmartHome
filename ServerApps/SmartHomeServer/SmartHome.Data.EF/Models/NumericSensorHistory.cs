using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class NumericSensorHistory : INumericSensorHistory
    {
        public long ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SysName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
