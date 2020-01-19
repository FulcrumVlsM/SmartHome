using System;

namespace SmartHome.Data.Interfaces.Models
{
    public interface IUserCondition
    {
        /// <summary>
        /// Связанный узел правила
        /// </summary>
        IRuleNode Node { get; set; }

        /// <summary>
        /// Связанный датчик
        /// </summary>
        IUser User { get; set; }

        /// <summary>
        /// Требуемое значение
        /// </summary>
        bool Value { get; set; }
    }
}
