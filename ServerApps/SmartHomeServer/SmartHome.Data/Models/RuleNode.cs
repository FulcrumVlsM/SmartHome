﻿using System.Collections.Generic;

namespace SmartHome.Data.Models
{
    public class RuleNode
    {
        public int ID { get; set; }

        public int RuleID { get; set; }
        public Rule Rule { get; set; }

        public List<BoolSensorCondition> BoolSensorConditions { get; set; }

        public List<NumericSensorCondition> NumericSensorConditions { get; set; }

        public List<TimeCondition> TimeConditions { get; set; }

        public ICollection<UserCondition> UserConditions { get; set; }
    }
}
