using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class TrackingBoolActionDeviceRepository : IRepository<BoolActionDevice>
    {
        protected readonly AppDatabaseContext _context;

        public TrackingBoolActionDeviceRepository(AppDatabaseContext context) => _context = context;

        
        public virtual BoolActionDevice this[int id] => _context.BoolActionDevices.FirstOrDefault(bad => bad.ID == id);

        public virtual BoolActionDevice this[string sysName] =>
            _context.BoolActionDevices.FirstOrDefault(bad => bad.SysName == sysName);

        public void Add(BoolActionDevice item) => _context.BoolActionDevices.Add(item);

        public bool Delete(int id)
        {
            var device = _context.BoolActionDevices.FirstOrDefault(bad => bad.ID == id);
            return Delete(device);
        }

        public bool Delete(BoolActionDevice item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.BoolActionDevices.Attach(item).State;
            }

            if (state == EntityState.Unchanged)
            {
                _context.BoolActionDevices.Remove(item);
                return true;
            }
            else return false;
        }

        public void Save() => _context.SaveChanges();

        public bool Update(BoolActionDevice item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.BoolActionDevices.Attach(item).State;
            }

            if (state != EntityState.Detached && state != EntityState.Deleted)
            {
                _context.BoolActionDevices.Update(item);
                return true;
            }
            else return false;
        }



        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_context.BoolActionDevices).GetEnumerator();

        public virtual IEnumerator<BoolActionDevice> GetEnumerator() => 
            ((IEnumerable<BoolActionDevice>)_context.BoolActionDevices).GetEnumerator();
    }
}
