using System;

namespace SmartHome.Data.Interfaces.Models
{
    public interface IEventDeviceHistory
    {
        long ID { get; set; }

        DateTime CreateDate { get; set; }

        IEventDevice Device { get; set; }
    }
}
