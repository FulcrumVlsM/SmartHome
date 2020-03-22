namespace SmartHome.Data.Models
{
    public class UserCondition
    {
        public int RuleNodeID { get; set; }
        public RuleNode Node { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public bool Value { get; set; }//TODO: Переименовать на RequiredInHomeValue
    }
}
