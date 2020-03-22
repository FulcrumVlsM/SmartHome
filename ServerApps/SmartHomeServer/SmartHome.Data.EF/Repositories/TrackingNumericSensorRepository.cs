using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class TrackingNumericSensorRepository : IRepository<NumericSensor>, IDisposable
    {
        protected readonly AppDatabaseContext _context;

        public TrackingNumericSensorRepository(AppDatabaseContext context) => _context = context;

        protected virtual IQueryable<NumericSensor> NumericSensors =>
            _context.NumericSensors.Include(ns => ns.Conditions).ThenInclude(nsc => nsc.Node).ThenInclude(rn => rn.Rule);

        
        public NumericSensor this[int id] => NumericSensors.FirstOrDefault(ns => ns.ID == id);

        public NumericSensor this[string sysName] => NumericSensors.FirstOrDefault(ns => ns.SysName == sysName);

        public NumericSensor this[NumericSensor item] => this[item.ID];

        public void Add(NumericSensor item) => _context.NumericSensors.Add(item);

        public bool Delete(int id)
        {
            var sensor = this[id];
            if (sensor != null) return Delete(sensor);
            else return false;
        }

        public bool Delete(NumericSensor item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.NumericSensors.Attach(item).State;
            }

            if (state == EntityState.Unchanged)
            {
                _context.NumericSensors.Remove(item);
                return true;
            }
            else return false;
        }

        public void Save() => _context.SaveChanges();

        public bool Update(NumericSensor item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.NumericSensors.Attach(item).State;
            }

            if (state != EntityState.Detached && state != EntityState.Deleted)
            {
                _context.NumericSensors.Update(item);
                return true;
            }
            else return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)NumericSensors).GetEnumerator();

        public IEnumerator<NumericSensor> GetEnumerator() => NumericSensors.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
