using System;
using SmartHome.Common.Enums;

namespace SmartHome.Data.Models
{
    public class TimeCondition
    {
        public int ID { get; set; }
        
        public int RuleNodeID { get; set; }
        public RuleNode Node { get; set; }
        
        public TimeSpan Value { get; set; }
        
        public ComparisonMode ComparisonMode { get; set; }
    }
}
