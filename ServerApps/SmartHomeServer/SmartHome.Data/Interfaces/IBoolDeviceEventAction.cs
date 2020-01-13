using SmartHome.Common.Enums;

namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс действия-реакции на событие
    /// </summary>
    public interface IBoolDeviceEventAction
    {
        /// <summary>
        /// Событийное устройство
        /// </summary>
        IEventDevice EventDevice { get; set; }

        /// <summary>
        /// Исполнительное устройство
        /// </summary>
        IBoolActionDevice Device { get; set; }

        /// <summary>
        /// Устанавливаемое устройству значение
        /// </summary>
        DeviceStateMode TargetStateMode { get; set; }
    }
}
