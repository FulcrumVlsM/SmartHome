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
        
        public List<IBoolActionDevice> BoolActionDevices { get; set; }
        
        public List<IEventDevice> EventDevices { get; set; }
        
        public List<IRuleNode> Nodes { get; set; }
    }
}
