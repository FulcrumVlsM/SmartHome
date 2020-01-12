using System;
using System.Collections.Generic;
using SmartHome.Data.Enums;

namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс исполнительного устройства логического типа
    /// </summary>
    public interface IBoolDevice
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Системное имя
        /// </summary>
        string SysName { get; set; }

        /// <summary>
        /// Публичное имя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Текущий режим работы устройства
        /// </summary>
        DeviceStateMode ActivityMode { get; set; }

        /// <summary>
        /// Дата и время создания компонента
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата и время последней активности компонента
        /// </summary>
        DateTime LastActivity { get; set; }


        /// <summary>
        /// Сваязанные с устройством правила
        /// </summary>
        List<IDeviceRule> Rules { get; set; }
    }
}
