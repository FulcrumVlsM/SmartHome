using System;
using System.ComponentModel.DataAnnotations;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class EventDeviceHistory : IEventDeviceHistory
    {
        [Key]
        public long ID { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        [Required]
        [MaxLength(1024)]
        public string SysName { get; set; }
    }
}
