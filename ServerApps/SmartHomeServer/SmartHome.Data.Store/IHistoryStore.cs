using SmartHome.Data.Models;
using System;

namespace SmartHome.Data.Store
{
    public interface IHistoryStore : IDisposable
    {
        IHistoryRepository<BoolActionDeviceHistoryItem> BoolActionDeviceHistory { get; }

        IHistoryRepository<BoolSensorHistoryItem> BoolSensorHistory { get; }

        IHistoryRepository<EventDeviceHistoryItem> EventDeviceHistory { get; }

        IHistoryRepository<NumericSensorHistoryItem> NumericSensorHistory { get; }

        IHistoryRepository<UserActionHistoryItem> UserActionHistory { get; }
    }
}
