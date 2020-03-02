using SmartHome.Data.Models;
using SmartHome.Data.EF.Repositories;
using SmartHome.Data.EF;

namespace SmartHome.Data.Store.Stores
{
    internal class EFHistoryStore : IHistoryStore
    {
        public IHistoryRepository<BoolActionDeviceHistoryItem> BoolActionDeviceHistory =>
            new BoolActionDeviceHistoryRepository(new AppDatabaseContext());

        public IHistoryRepository<BoolSensorHistoryItem> BoolSensorHistory =>
            new BoolSensorHistoryRepository(new AppDatabaseContext());

        public IHistoryRepository<EventDeviceHistoryItem> EventDeviceHistory =>
            new EventDeviceHistoryRepository(new AppDatabaseContext());

        public IHistoryRepository<NumericSensorHistoryItem> NumericSensorHistory =>
            new NumericSensorHistoryRepository(new AppDatabaseContext());

        public IHistoryRepository<UserActionHistoryItem> UserActionHistory =>
            new UserActionHistoryRepository(new AppDatabaseContext());
    }
}
