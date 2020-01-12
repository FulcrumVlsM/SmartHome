using System;

namespace SmartHome.Data.Interfaces
{
    interface IUserCondition
    {
        /// <summary>
        /// Идентификатор узла правила
        /// </summary>
        int NodeID { get; set; }

        /// <summary>
        /// Идентификатор логического датчика
        /// </summary>
        Guid UserID { get; set; }

        /// <summary>
        /// Требуемое значение
        /// </summary>
        bool Value { get; set; }


        /// <summary>
        /// Связанный узел правила
        /// </summary>
        IRuleNode Node { get; set; }

        /// <summary>
        /// Связанный датчик
        /// </summary>
        IUser User { get; set; }
    }
}
