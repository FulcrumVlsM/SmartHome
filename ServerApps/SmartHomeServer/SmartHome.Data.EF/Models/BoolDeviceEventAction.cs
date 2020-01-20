using System;
using SmartHome.Common.Enums;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class BoolDeviceEventAction : IBoolDeviceEventAction
    {
        public int EventDeviceID { get; set; }
        public EventDevice EventDevice { get; set; }

        public int BoolActionDeviceID { get; set; }
        public BoolActionDevice Device { get; set; }

        public DeviceStateMode TargetStateMode { get; set; }



        IEventDevice IBoolDeviceEventAction.EventDevice { get => EventDevice; set => throw new NotImplementedException(); }

        IBoolActionDevice IBoolDeviceEventAction.Device { get => Device; set => throw new NotImplementedException(); }
    }
}
