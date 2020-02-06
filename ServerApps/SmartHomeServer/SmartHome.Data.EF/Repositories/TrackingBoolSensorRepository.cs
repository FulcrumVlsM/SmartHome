using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class TrackingBoolSensorRepository : IRepository<BoolSensor>
    {
        protected readonly AppDatabaseContext _context;

        public TrackingBoolSensorRepository(AppDatabaseContext context) => _context = context;


        protected virtual IQueryable<BoolSensor> BoolSensors => _context.BoolSensors
            .Include(bs => bs.Conditions).ThenInclude(bsc => bsc.Node);
        
        public virtual BoolSensor this[int id] => BoolSensors.FirstOrDefault(bs => bs.ID == id);

        public virtual BoolSensor this[string sysName] => BoolSensors.FirstOrDefault(bs => bs.SysName== sysName);

        public virtual BoolSensor this[BoolSensor item] => this[item.ID];

        public void Add(BoolSensor item) => _context.BoolSensors.Add(item);

        public bool Delete(int id)
        {
            var sensor = this[id];
            if (sensor != null) return Delete(sensor);
            else return false;
        }

        public bool Delete(BoolSensor item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.BoolSensors.Attach(item).State;
            }

            if (state == EntityState.Unchanged)
            {
                _context.BoolSensors.Remove(item);
                return true;
            }
            else return false;
        }

        public void Save() => _context.SaveChanges();

        public bool Update(BoolSensor item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.BoolSensors.Attach(item).State;
            }

            if (state != EntityState.Detached && state != EntityState.Deleted)
            {
                _context.BoolSensors.Update(item);
                return true;
            }
            else return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)BoolSensors).GetEnumerator();

        public virtual IEnumerator<BoolSensor> GetEnumerator() => BoolSensors.GetEnumerator();
    }
}
