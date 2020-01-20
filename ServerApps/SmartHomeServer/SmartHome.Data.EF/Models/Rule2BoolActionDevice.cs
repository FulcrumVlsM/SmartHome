using System;
using SmartHome.Data.Interfaces.Models;

namespace SmartHome.Data.EF.Models
{
    internal class Rule2BoolActionDevice : IRule2BoolActionDevice
    {
        public int RuleID { get; set; }
        public Rule Rule { get; set; }

        public int BoolActionDeviceID { get; set; }
        public BoolActionDevice Device { get; set; }

        
        IRule IRule2BoolActionDevice.Rule { get => Rule; set => throw new NotImplementedException(); }
        IBoolActionDevice IRule2BoolActionDevice.Device { get => Device; set => throw new NotImplementedException(); }
    }
}
