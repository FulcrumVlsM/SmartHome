using SmartHome.Data.Models;
using SmartHome.Data.EF.Repositories;
using SmartHome.Data.EF;

namespace SmartHome.Data.Store.Stores
{
    internal class EFHistoryStore : IHistoryStore
    {
        public IHistoryRepository<BoolActionDeviceHistory> BoolActionDeviceHistory =>
            new BoolActionDeviceHistoryRepository(new AppDatabaseContext());

        public IHistoryRepository<BoolSensorHistory> BoolSensorHistory =>
            new BoolSensorHistoryRepository(new AppDatabaseContext());

        public IHistoryRepository<EventDeviceHistory> EventDeviceHistory =>
            new EventDeviceHistoryRepository(new AppDatabaseContext());

        public IHistoryRepository<NumericSensorHistory> NumericSensorHistory =>
            new NumericSensorHistoryRepository(new AppDatabaseContext());

        public IHistoryRepository<UserActionHistory> UserActionHistory =>
            new UserActionHistoryRepository(new AppDatabaseContext());
    }
}
