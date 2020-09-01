using SmartHome.Data.Models;
using SmartHome.Data.EF;
using SmartHome.Data.EF.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

namespace SmartHome.Data.Store.Stores
{
    internal class EFSimpleDataStore : IDataStore
    {
        private readonly AppDatabaseContext _context;

        internal EFSimpleDataStore(string connectionString)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString);
            _context = new AppDatabaseContext(builder.Options);
        }


        public IRepository<BoolActionDevice> BoolActionDevices => new UntrackingBoolActionDeviceRepository(_context);


        public IRepository<BoolSensor> BoolSensors => new UntrackingBoolSensorRepository(_context);


        public IRepository<EventDevice> EventDevices => new UntrackingEventDeviceRepository(_context);


        public IRepository<NumericSensor> NumericSensors => new UntrackingNumericSensorRepository(_context);


        public IRepository<Rule> Rules => new UntrackingRuleRepository(_context);


        public IRepository<SmartCard> SmartCards => new UntrackingSmartCardRepository(_context);


        public IRepository<User> Users => new UntrackingUserRepository(_context);

        public IRepository<EventActionDevice> EventActionDevices => new UntrackingEventActionDeviceRepository(_context);
    }
}
