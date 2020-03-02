using SmartHome.Data.Models;

namespace SmartHome.Data.Store
{
    public interface IHistoryStore
    {
        IHistoryRepository<BoolActionDeviceHistory> BoolActionDeviceHistory { get; }

        IHistoryRepository<BoolSensorHistory> BoolSensorHistory { get; }

        IHistoryRepository<EventDeviceHistory> EventDeviceHistory { get; }

        IHistoryRepository<NumericSensorHistory> NumericSensorHistory { get; }

        IHistoryRepository<UserActionHistory> UserActionHistory { get; }
    }
}
