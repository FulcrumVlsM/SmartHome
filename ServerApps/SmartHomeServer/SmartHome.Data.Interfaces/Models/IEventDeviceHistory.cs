using System;

namespace SmartHome.Data.Interfaces.Models
{
    public interface IEventDeviceHistory
    {
        long ID { get; set; }

        DateTime CreateDate { get; set; }

        /// <summary>
        /// Системное имя датчика, от которого пришло значение
        /// </summary>
        string SysName { get; set; }
    }
}
