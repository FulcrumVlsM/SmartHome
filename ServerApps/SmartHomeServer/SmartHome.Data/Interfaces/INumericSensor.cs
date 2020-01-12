using System;

namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс числового датчика
    /// </summary>
    public interface INumericSensor
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
        /// Состояние активности датчика
        /// </summary>
        bool ActivityMode { get; set; }

        /// <summary>
        /// Текущее значение
        /// </summary>
        float Value { get; set; }

        //TODO: еще не добавлен тип датчика
    }
}
