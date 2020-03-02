using SmartHome.Data.Models;
using SmartHome.Data.EF;
using SmartHome.Data.EF.Repositories;

namespace SmartHome.Data.Store.Stores
{
    internal sealed class EFControllerStore : IDataStore
    {
        public IRepository<BoolActionDevice> BoolActionDevices => 
            new TrackingBoolActionDeviceRepository(new AppDatabaseContext());


        public IRepository<BoolSensor> BoolSensors =>
            new TrackingBoolSensorRepository(new AppDatabaseContext());



        private TrackingEventDeviceRepository _eventDevices;
        public IRepository<EventDevice> EventDevices => new TrackingEventDeviceRepository(new AppDatabaseContext());


        public IRepository<NumericSensor> NumericSensors => 
            new TrackingNumericSensorRepository(new AppDatabaseContext());


        public IRepository<Rule> Rules => new UntrackingRuleRepository(new AppDatabaseContext());


        public IRepository<SmartCard> SmartCards =>
            new UntrackingSmartCardRepository(new AppDatabaseContext());


        public IRepository<User> Users =>
            new UntrackingUserRepository(new AppDatabaseContext());
    }
}
