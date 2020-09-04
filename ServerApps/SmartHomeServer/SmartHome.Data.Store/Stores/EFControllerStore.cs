using SmartHome.Data.Models;
using SmartHome.Data.EF;
using SmartHome.Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SmartHome.Data.Store.Stores
{
    /// <summary>
    /// Хранилище данных для использования в контроллере УД
    /// </summary>
    internal sealed class EFControllerStore : IDataStore
    {
        private readonly AppDatabaseContext _context;

        internal EFControllerStore(string connectionString)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString);
            _context = new AppDatabaseContext(builder.Options);
        }


        private IRepository<BoolActionDevice> _boolActionDevices = null;
        public IRepository<BoolActionDevice> BoolActionDevices
        {
            get
            {
                if(_boolActionDevices == null)
                    _boolActionDevices = new TrackingBoolActionDeviceRepository(_context);
                return _boolActionDevices;
            }
        }


        private IRepository<BoolSensor> _boolSensors = null;
        public IRepository<BoolSensor> BoolSensors
        {
            get
            {
                if(_boolSensors == null)
                    _boolSensors = new TrackingBoolSensorRepository(_context);
                return _boolSensors;
            }
        }


        private IRepository<EventDevice> _eventDevices = null;
        public IRepository<EventDevice> EventDevices
        {
            get
            {
                if(_eventDevices == null)
                    _eventDevices = new TrackingEventDeviceRepository(_context);
                return _eventDevices;
            }
        }


        private IRepository<NumericSensor> _numericSensors = null;
        public IRepository<NumericSensor> NumericSensors
        {
            get
            {
                if(_numericSensors == null)
                    _numericSensors = new TrackingNumericSensorRepository(_context);
                return _numericSensors;
            }
        }


        private IRepository<Rule> _rules = null;
        public IRepository<Rule> Rules
        {
            get
            {
                if(_rules == null)
                    _rules = new UntrackingRuleRepository(_context);
                return _rules;
            }
        }


        private IRepository<SmartCard> _smartCards = null;
        public IRepository<SmartCard> SmartCards
        {
            get
            {
                if(_smartCards == null)
                    _smartCards = new UntrackingSmartCardRepository(_context);
                return _smartCards;
            }
        }


        private IRepository<User> _users;
        public IRepository<User> Users
        {
            get
            {
                if(_users == null)
                    _users = new UntrackingUserRepository(_context);
                return _users;
            }
        }

        private IRepository<EventActionDevice> _eventActionDevices;
        public IRepository<EventActionDevice> EventActionDevices
        {
            get
            {
                if(_eventActionDevices == null)
                    _eventActionDevices = new TrackingEventActionDeviceRepository(_context);
                return _eventActionDevices;
            }
        }
    }
}
