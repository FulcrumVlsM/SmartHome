namespace SmartHome.Data.Interfaces.Models
{
    /// <summary>
    /// Интерфейс связующей сущности многие-ко-многим между правилами и логическими устройствами
    /// </summary>
    public interface IRule2BoolActionDevice
    {
        IRule Rule { get; set; }

        IBoolActionDevice Device { get; set; }
    }
}
