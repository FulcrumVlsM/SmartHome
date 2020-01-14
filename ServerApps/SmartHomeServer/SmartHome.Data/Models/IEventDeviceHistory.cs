using System;

namespace SmartHome.Data.Models
{
    public interface IEventDeviceHistory
    {
        int ID { get; set; }

        DateTime CreateDate { get; set; }

        IEventDevice Device { get; set; }
    }
}
