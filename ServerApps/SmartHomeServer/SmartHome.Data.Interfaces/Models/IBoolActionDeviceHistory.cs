using System;

namespace SmartHome.Data.Interfaces.Models
{
    /// <summary>
    /// Лог состояния исполнительного устройства
    /// </summary>
    public interface IBoolActionDeviceHistory
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        long ID { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        bool Value { get; set; }

        /// <summary>
        /// Дата лога
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Исполнительное устройство
        /// </summary>
        IBoolActionDevice Device { get; set; }
    }
}
