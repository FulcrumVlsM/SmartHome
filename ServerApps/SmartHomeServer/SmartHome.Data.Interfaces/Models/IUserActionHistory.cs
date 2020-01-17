namespace SmartHome.Data.Interfaces.Models
{
    public interface IUserActionHistory
    {
        long ID { get; set; }

        bool Value { get; set; }

        IUser User { get; set; }

        ISmartCard SmartCard { get; set; }
    }
}
