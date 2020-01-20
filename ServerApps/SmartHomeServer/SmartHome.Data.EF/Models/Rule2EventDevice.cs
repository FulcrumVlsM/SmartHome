using System;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class Rule2EventDevice : IRule2EventDevice
    {
        public int RuleID { get; set; }
        public Rule Rule { get; set; }

        public int EventDeviceID { get; set; }
        public EventDevice Device { get; set; }


        IRule IRule2EventDevice.Rule { get => Rule; set => throw new NotImplementedException(); }
        IEventDevice IRule2EventDevice.Device { get => Device; set => throw new NotImplementedException(); }
    }
}
