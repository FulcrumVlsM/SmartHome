using System;
using System.Collections.Generic;

namespace SmartHome.Data.Interfaces.Models
{
    /// <summary>
    /// Интерфейс логического датчика
    /// </summary>
    public interface IBoolSensor
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Системное имя датчика
        /// </summary>
        string SysName { get; set; }

        /// <summary>
        /// Публичное имя датчика
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Время последней активности
        /// </summary>
        DateTime LastActivity { get; set; }

        /// <summary>
        /// Режим работы датчика
        /// </summary>
        bool ActivityMode { get; set; }

        /// <summary>
        /// Текущее значение
        /// </summary>
        bool Value { get; set; }

        /// <summary>
        /// Условия, связанные с датчиком
        /// </summary>
        List<IBoolSensorCondition> Conditions { get; }

        //TODO: еще не добавлен тип датчика
    }
}
