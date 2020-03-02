using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class TrackingBoolActionDeviceRepository : IRepository<BoolActionDevice>, IDisposable
    {
        protected readonly AppDatabaseContext _context;

        protected virtual IQueryable<BoolActionDevice> BoolActionDevices =>
            _context.BoolActionDevices.Include(bad => bad.Rule2BoolActionDevices).ThenInclude(r2bad => r2bad.Rule)
            .Include(bad => bad.EventActions).ThenInclude(bdea => bdea.EventDevice);

        public TrackingBoolActionDeviceRepository(AppDatabaseContext context) => _context = context;

        
        public virtual BoolActionDevice this[int id] => 
            BoolActionDevices.FirstOrDefault(bad => bad.ID == id);

        public virtual BoolActionDevice this[string sysName] =>
            BoolActionDevices.FirstOrDefault(bad => bad.SysName == sysName);

        public virtual BoolActionDevice this[BoolActionDevice item] => this[item.ID];

        public void Add(BoolActionDevice item) => _context.BoolActionDevices.Add(item);

        public bool Delete(int id)
        {
            var device = this[id];
            if (device != null) return Delete(device);
            else return false;
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



        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)BoolActionDevices).GetEnumerator();

        public virtual IEnumerator<BoolActionDevice> GetEnumerator() => BoolActionDevices.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
