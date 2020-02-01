using System;
using System.Collections.Generic;

namespace SmartHome.Data.Models
{
    public class Rule
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreateDate { get; set; }


        public ICollection<Rule2BoolActionDevice> Rule2BoolActionDevices { get; set; }

        public ICollection<Rule2EventDevice> Rule2EventDevices { get; set; }

        public ICollection<RuleNode> Nodes { get; set; }
    }
}
