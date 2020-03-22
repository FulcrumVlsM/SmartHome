using SmartHome.Data.Models;
using SmartHome.Data.EF;
using SmartHome.Data.EF.Repositories;
using System;

namespace SmartHome.Data.Store.Stores
{
    internal class EFSimpleDataStore : IDataStore
    {
        private readonly AppDatabaseContext _context;

        internal EFSimpleDataStore() => _context = new AppDatabaseContext();


        public IRepository<BoolActionDevice> BoolActionDevices => new UntrackingBoolActionDeviceRepository(_context);


        public IRepository<BoolSensor> BoolSensors => new UntrackingBoolSensorRepository(_context);


        public IRepository<EventDevice> EventDevices => new UntrackingEventDeviceRepository(_context);


        public IRepository<NumericSensor> NumericSensors => new UntrackingNumericSensorRepository(_context);


        public IRepository<Rule> Rules => new UntrackingRuleRepository(_context);


        public IRepository<SmartCard> SmartCards => new UntrackingSmartCardRepository(_context);


        public IRepository<User> Users => new UntrackingUserRepository(_context);

        public IRepository<EventActionDevice> EventActionDevices => new UntrackingEventActionDeviceRepository(_context);

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
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


        ~EFSimpleDataStore() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
