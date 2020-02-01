using SmartHome.Data.Models;

namespace SmartHome.Data.Store
{
    interface IDataStore
    {
        IRepository<BoolActionDevice> BoolActionDevices { get; }

        IRepository<BoolActionDeviceHistory> BoolActionDeviceHistory { get; }

        IRepository<BoolDeviceEventAction> BoolDeviceEventAction { get; }

        IRepository<BoolSensor> BoolSensors { get; }

        IRepository<BoolSensorHistory> BoolSensorHistory { get; }

        IRepository<EventDevice> EventDevices { get; }

        IRepository<EventDeviceHistory> EventDeviceHistory { get; }

        IRepository<NumericSensor> NumericSensors { get; }

        IRepository<NumericSensorHistory> NumericSensorHistory { get; }

        IRepository<Rule> Rules { get; }

        IRepository<RuleNode> RuleNodes { get; }

        IRepository<SmartCard> SmartCards { get; }

        IRepository<User> Users { get; }

        IRepository<UserActionHistory> UserActionHistory { get; }
    }
}
