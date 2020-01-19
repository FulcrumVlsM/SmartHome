using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class User : IUser
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [MaxLength(1024)]
        public string Name { get; set; }
        
        public bool InHome { get; set; }
        

        public List<ISmartCard> SmartCards { get; set; }

        public List<IUserCondition> Conditions { get; set; }
    }
}
