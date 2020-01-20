using SmartHome.Common.Enums;
using System;
using System.Collections.Generic;

namespace SmartHome.Data.Interfaces.Models
{
    /// <summary>
    /// Интерфейс исполнительного устройства логического типа
    /// </summary>
    public interface IBoolActionDevice
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
        DateTime LastActivityDate { get; set; }

        /// <summary>
        /// Категория устройства
        /// </summary>
        DeviceCategory Category { get; set; }


        /// <summary>
        /// Сваязанные с устройством правила
        /// </summary>
        List<IRule2BoolActionDevice> Rule2BoolActionDevices { get; }

        /// <summary>
        /// Связанные с устройством событийные действия
        /// </summary>
        List<IBoolDeviceEventAction> EventActions { get; }
    }
}
