using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome.Data.EF.Repositories
{
    public class TrackingEventActionDeviceRepository : IRepository<EventActionDevice>
    {
        protected readonly AppDatabaseContext _context;

        protected virtual IQueryable<EventActionDevice> EventActionDevices =>
            _context.EventActionDevices.Include(ead => ead.EventDevices2EventActionDevice)
            .ThenInclude(ed2ead => ed2ead.EventDevice);

        public TrackingEventActionDeviceRepository(AppDatabaseContext context) => _context = context;

        
        public EventActionDevice this[int id] => EventActionDevices.FirstOrDefault(ead => ead.ID == id);

        public EventActionDevice this[string sysName] => EventActionDevices.FirstOrDefault(ead => ead.SysName == sysName);

        public EventActionDevice this[EventActionDevice item] => this[item.ID];

        public void Add(EventActionDevice item) => _context.EventActionDevices.Add(item);

        public bool Delete(int id)
        {
            var device = this[id];
            if (device != null) return Delete(device);
            else return false;
        }

        public bool Delete(EventActionDevice item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.EventActionDevices.Attach(item).State;
            }

            if (state == EntityState.Unchanged)
            {
                _context.EventActionDevices.Remove(item);
                return true;
            }
            else return false;
        }

        public void Save() => _context.SaveChanges();

        public bool Update(EventActionDevice item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.EventActionDevices.Attach(item).State;
            }

            if (state != EntityState.Detached && state != EntityState.Deleted)
            {
                _context.EventActionDevices.Update(item);
                return true;
            }
            else return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)EventActionDevices).GetEnumerator();

        public IEnumerator<EventActionDevice> GetEnumerator() => EventActionDevices.GetEnumerator();
    }
}
