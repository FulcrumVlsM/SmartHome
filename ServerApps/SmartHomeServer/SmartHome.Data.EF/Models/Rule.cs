using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class Rule : IRule
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public DateTime CreateDate { get; set; }


        List<IRule2BoolActionDevice> IRule.Rule2BoolActionDevices => Rule2BoolActionDevices
            .ConvertAll<IRule2BoolActionDevice>(x => x);

        List<IRule2EventDevice> IRule.Rule2EventDevices => Rule2EventDevices
            .ConvertAll<IRule2EventDevice>(x => x);

        List<IRuleNode> IRule.Nodes => Nodes.ConvertAll<IRuleNode>(x => x);


        public List<Rule2BoolActionDevice> Rule2BoolActionDevices { get; set; }

        public List<Rule2EventDevice> Rule2EventDevices { get; set; }

        public List<RuleNode> Nodes { get; set; }
    }
}
