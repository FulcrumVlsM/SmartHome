using System;
using System.Collections.Generic;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class RuleNode : IRuleNode
    {
        public Rule Rule { get; set; }

        public List<BoolSensorCondition> BoolSensorConditions { get; set; }

        public List<NumericSensorCondition> NumericSensorConditions { get; set; }

        public List<TimeCondition> TimeConditions { get; set; }

        
        IRule IRuleNode.Rule { get => Rule; set => throw new NotImplementedException(); }

        List<IBoolSensorCondition> IRuleNode.BoolSensorConditions => BoolSensorConditions
            .ConvertAll<IBoolSensorCondition>(x => x);

        List<INumericSensorCondition> IRuleNode.NumericSensorConditions => NumericSensorConditions
            .ConvertAll<INumericSensorCondition>(x => x);

        List<ITimeCondition> IRuleNode.TimeConditions => TimeConditions.
            ConvertAll<ITimeCondition>(x => x);
    }
}
