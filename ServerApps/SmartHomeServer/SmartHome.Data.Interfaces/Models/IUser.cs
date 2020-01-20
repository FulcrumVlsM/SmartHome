using System;
using System.Collections.Generic;

namespace SmartHome.Data.Interfaces.Models
{
    /// <summary>
    /// Интерфейс описывающий пользователя (жильца дома)
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Находится ли пользователь дома
        /// </summary>
        bool InHome { get; set; }


        /// <summary>
        /// Смарт-карты, привязанные к пользователю
        /// </summary>
        List<ISmartCard> SmartCards { get; }

        /// <summary>
        /// Условия связанные с пользователем
        /// </summary>
        List<IUserCondition> Conditions { get; }
    }
}
