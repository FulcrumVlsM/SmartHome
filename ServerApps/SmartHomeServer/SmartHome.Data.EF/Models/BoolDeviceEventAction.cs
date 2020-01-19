using System;
using System.ComponentModel.DataAnnotations.Schema;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolDeviceEventAction : IBoolDeviceEventAction
    {
        internal EventDevice EventDevice { get; set; }

        internal BoolActionDevice Device { get; set; }

        DeviceStateMode IBoolDeviceEventAction.TargetStateMode { get; set; }


        [NotMapped]
        IEventDevice IBoolDeviceEventAction.EventDevice { get => EventDevice; set => throw new NotImplementedException(); }
        
        [NotMapped]
        IBoolActionDevice IBoolDeviceEventAction.Device { get => Device; set => throw new NotImplementedException(); }
    }
}
