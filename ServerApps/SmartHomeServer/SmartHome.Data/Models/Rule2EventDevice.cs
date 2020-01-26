namespace SmartHome.Data.Models
{
    public class Rule2EventDevice
    {
        public int RuleID { get; set; }
        public Rule Rule { get; set; }

        public int EventDeviceID { get; set; }
        public EventDevice Device { get; set; }
    }
}
