using System;

namespace SmartHome.Data.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий объект смарт-карты, которая используется для входа в дом
    /// </summary>
    public interface ISmartCard
    {
        /// <summary>
        /// Ключ смарт-карты
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Идентифкатор привязанного пользователя
        /// </summary>
        Guid UserID { get; set; }

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
