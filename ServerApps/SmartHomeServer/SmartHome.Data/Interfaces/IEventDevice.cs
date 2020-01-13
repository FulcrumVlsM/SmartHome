﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс событийного устройства
    /// </summary>
    public interface IEventDevice
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Публичное наименование
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Системное наименование
        /// </summary>
        string SysName { get; set; }

        /// <summary>
        /// Состояние устройства
        /// </summary>
        bool Enable { get; set; }

        /// <summary>
        /// Дата и время создания устройства
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата и время последнего события
        /// </summary>
        DateTime LastEventDate { get; set; }


        /// <summary>
        /// Условия для наступления действий при событии
        /// </summary>
        List<IRule> Conditions { get; set; }

        /// <summary>
        /// Действия в ответ на событие
        /// </summary>
        List<IBoolDeviceEventAction> Actions { get; set; }
    }
}
