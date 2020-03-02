using SmartHome.Data.Models;

namespace SmartHome.Data.Store
{
    public interface IHistoryStore
    {
        IHistoryRepository<BoolActionDeviceHistoryItem> BoolActionDeviceHistory { get; }

        IHistoryRepository<BoolSensorHistoryItem> BoolSensorHistory { get; }

        IHistoryRepository<EventDeviceHistoryItem> EventDeviceHistory { get; }

        IHistoryRepository<NumericSensorHistoryItem> NumericSensorHistory { get; }

        IHistoryRepository<UserActionHistoryItem> UserActionHistory { get; }
    }
}
