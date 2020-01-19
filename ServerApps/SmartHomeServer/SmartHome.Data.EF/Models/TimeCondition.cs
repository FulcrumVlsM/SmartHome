using System;
using System.Collections.Generic;
using System.Text;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class TimeCondition : ITimeCondition
    {
        public IRuleNode Node { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeSpan Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ComparisonMode ComparisonMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
