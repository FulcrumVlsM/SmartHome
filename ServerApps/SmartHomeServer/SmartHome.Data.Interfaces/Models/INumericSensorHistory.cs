using System;

namespace SmartHome.Data.Interfaces.Models
{
    public interface INumericSensorHistory
    {
        long ID { get; set; }

        float Value { get; set; }

        DateTime CreateDate { get; set; }

        /// <summary>
        /// Системное имя датчика, от которого пришло значение
        /// </summary>
        string SysName { get; set; }
    }
}
