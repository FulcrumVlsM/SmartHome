using SmartHome.Data.Models;
using SmartHome.Data.EF;
using SmartHome.Data.EF.Repositories;
using System;

namespace SmartHome.Data.Store.Stores
{
    internal sealed class EFControllerStore : IDataStore
    {
        private readonly AppDatabaseContext _context;

        internal EFControllerStore() => _context = new AppDatabaseContext();


        public IRepository<BoolActionDevice> BoolActionDevices => new TrackingBoolActionDeviceRepository(_context);


        public IRepository<BoolSensor> BoolSensors => new TrackingBoolSensorRepository(_context);



        public IRepository<EventDevice> EventDevices => new TrackingEventDeviceRepository(_context);


        public IRepository<NumericSensor> NumericSensors => new TrackingNumericSensorRepository(_context);


        public IRepository<Rule> Rules => new UntrackingRuleRepository(_context);


        public IRepository<SmartCard> SmartCards => new UntrackingSmartCardRepository(_context);


        public IRepository<User> Users => new UntrackingUserRepository(_context);

        public IRepository<EventActionDevice> EventActionDevices => new TrackingEventActionDeviceRepository(_context);

        #region IDisposable Support
        private bool disposedValue = false;

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                _context.Dispose();
                disposedValue = true;
            }
        }


         ~EFControllerStore()
        {
            Dispose(false);
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
