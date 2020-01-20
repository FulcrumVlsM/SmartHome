using System;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolDeviceEventAction : IBoolDeviceEventAction
    {
        public EventDevice EventDevice { get; set; }

        public BoolActionDevice Device { get; set; }

        public DeviceStateMode TargetStateMode { get; set; }


        [NotMapped]
        IEventDevice IBoolDeviceEventAction.EventDevice { get => EventDevice; set => throw new NotImplementedException(); }
        
        [NotMapped]
        IBoolActionDevice IBoolDeviceEventAction.Device { get => Device; set => throw new NotImplementedException(); }
    }
}
