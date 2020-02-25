using SmartHome.Data.Models;
using SmartHome.Data.EF;
using SmartHome.Data.EF.Repositories;

namespace SmartHome.Data.Store.Stores
{
    internal class EFSimpleDataStore : IDataStore
    {
        public IRepository<BoolActionDevice> BoolActionDevices =>
            new UntrackingBoolActionDeviceRepository(new AppDatabaseContext());


        public IRepository<BoolSensor> BoolSensors =>
            new UntrackingBoolSensorRepository(new AppDatabaseContext());


        public IRepository<EventDevice> EventDevices => 
            new UntrackingEventDeviceRepository(new AppDatabaseContext());


        public IRepository<NumericSensor> NumericSensors => 
            new UntrackingNumericSensorRepository(new AppDatabaseContext());


        public IRepository<Rule> Rules =>
            new UntrackingRuleRepository(new AppDatabaseContext());


        public IRepository<SmartCard> SmartCards =>
            new UntrackingSmartCardRepository(new AppDatabaseContext());


        public IRepository<User> Users => new UntrackingUserRepository(new AppDatabaseContext());
    }
}
