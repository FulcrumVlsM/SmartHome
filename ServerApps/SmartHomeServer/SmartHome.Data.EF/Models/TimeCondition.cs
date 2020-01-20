using System;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class TimeCondition : ITimeCondition
    {
        public RuleNode Node { get; set; }
        
        public TimeSpan Value { get; set; }
        
        public ComparisonMode ComparisonMode { get; set; }


        IRuleNode ITimeCondition.Node { get => Node; set => throw new NotImplementedException(); }
    }
}
