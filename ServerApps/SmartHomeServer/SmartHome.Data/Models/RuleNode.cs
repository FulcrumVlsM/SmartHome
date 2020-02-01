using System.Collections.Generic;

namespace SmartHome.Data.Models
{
    public class RuleNode
    {
        public int ID { get; set; }

        public int RuleID { get; set; }
        public Rule Rule { get; set; }

        public ICollection<BoolSensorCondition> BoolSensorConditions { get; set; }

        public ICollection<NumericSensorCondition> NumericSensorConditions { get; set; }

        public ICollection<TimeCondition> TimeConditions { get; set; }

        public ICollection<UserCondition> UserConditions { get; set; }
    }
}
