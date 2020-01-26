namespace SmartHome.Data.Models
{
    public class BoolSensorCondition
    {
        public int RuleNodeID { get; set; }
        public RuleNode Node { get; set; }

        public int BoolSensorID { get; set; }
        public BoolSensor Sensor { get; set; }

        public bool RequiredValue { get; set; }
    }
}
