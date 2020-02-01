using SmartHome.Common.Enums;

namespace SmartHome.Data.Models
{
    public class NumericSensorCondition
    {
        public int RuleNodeID { get; set; }
        public RuleNode Node { get; set; }

        public int NumericSensorID { get; set; }
        public NumericSensor Sensor { get; set; }

        public float Value { get; set; }
        
        public ComparisonMode ComparisonMode { get; set; }
    }
}
