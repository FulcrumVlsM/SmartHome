namespace SmartHome.Data.Interfaces.Models
{
    public interface IRule2EventDevice
    {
        IRule Rule { get; set; }

        IEventDevice Device { get; set; }
    }
}
