using System;

namespace SmartHome.Data.Interfaces.Models
{
    /// <summary>
    /// Интерфейс, описывающий объект смарт-карты, которая используется для входа в дом
    /// </summary>
    public interface ISmartCard
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Ключ смарт-карты
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Имя карты
        /// </summary>
        string Name { get; set; }


        /// <summary>
        /// Привязанный пользователь
        /// </summary>
        IUser User { get; set; }
    }
}
