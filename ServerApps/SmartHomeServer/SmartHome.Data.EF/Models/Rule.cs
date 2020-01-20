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


        List<IBoolActionDevice> IRule.BoolActionDevices => BoolActionDevices.ConvertAll<IBoolActionDevice>(x => x);

        List<IEventDevice> IRule.EventDevices => EventDevices.ConvertAll<IEventDevice>(x => x);

        List<IRuleNode> IRule.Nodes => Nodes.ConvertAll<IRuleNode>(x => x);


        public List<BoolActionDevice> BoolActionDevices { get; set; }

        public List<EventDevice> EventDevices { get; set; }

        public List<RuleNode> Nodes { get; set; }
    }
}
