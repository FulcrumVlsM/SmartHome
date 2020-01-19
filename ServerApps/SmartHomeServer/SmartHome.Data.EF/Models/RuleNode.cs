using System;
using System.Collections.Generic;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class RuleNode : IRuleNode
    {
        public IRule Rule { get; set; }
        
        public List<IBoolSensorCondition> BoolSensorConditions { get; set; }
        
        public List<INumericSensorCondition> NumericSensorConditions { get; set; }
        
        public List<ITimeCondition> TimeConditions { get; set; }
    }
}
