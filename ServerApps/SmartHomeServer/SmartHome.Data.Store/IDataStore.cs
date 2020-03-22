using SmartHome.Data.Models;
using System;

namespace SmartHome.Data.Store
{
    public interface IDataStore
    {
        IRepository<BoolActionDevice> BoolActionDevices { get; }

        IRepository<BoolSensor> BoolSensors { get; }

        IRepository<EventDevice> EventDevices { get; }

        IRepository<EventActionDevice> EventActionDevices { get; }

        IRepository<NumericSensor> NumericSensors { get; }

        IRepository<Rule> Rules { get; }

        IRepository<SmartCard> SmartCards { get; }

        IRepository<User> Users { get; }
    }
}
