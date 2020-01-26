namespace SmartHome.Data.Models
{
    public class Rule2BoolActionDevice
    {
        public int RuleID { get; set; }
        public Rule Rule { get; set; }

        public int BoolActionDeviceID { get; set; }
        public BoolActionDevice Device { get; set; }
    }
}
