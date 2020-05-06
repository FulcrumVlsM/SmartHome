using SmartHome.Data.Models;
using SmartHome.Data.EF.Repositories;
using SmartHome.Data.EF;
using System;
using Microsoft.EntityFrameworkCore;

namespace SmartHome.Data.Store.Stores
{
    internal class EFHistoryStore : IHistoryStore
    {
        private readonly AppDatabaseContext _context;

        internal EFHistoryStore(string connectionString)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString);
            _context = new AppDatabaseContext(builder.Options);

        }
        
        
        public IHistoryRepository<BoolActionDeviceHistoryItem> BoolActionDeviceHistory =>
            new BoolActionDeviceHistoryRepository(_context);

        public IHistoryRepository<BoolSensorHistoryItem> BoolSensorHistory =>
            new BoolSensorHistoryRepository(_context);

        public IHistoryRepository<EventDeviceHistoryItem> EventDeviceHistory =>
            new EventDeviceHistoryRepository(_context);

        public IHistoryRepository<NumericSensorHistoryItem> NumericSensorHistory =>
            new NumericSensorHistoryRepository(_context);

        public IHistoryRepository<UserActionHistoryItem> UserActionHistory =>
            new UserActionHistoryRepository(_context);

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

        ~EFHistoryStore() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
