using System;

namespace SmartHome.Data.Interfaces.Models
{
    public interface IBoolSensorHistory
    {
        long ID { get; set; }

        bool Value { get; set; }

        DateTime CreateDate { get; set; }

        /// <summary>
        /// Системное имя датчика, от которого пришло значение
        /// </summary>
        string SysName { get; set; }
    }
}
