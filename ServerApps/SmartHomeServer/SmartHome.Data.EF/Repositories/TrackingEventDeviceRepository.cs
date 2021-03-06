﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class TrackingEventDeviceRepository : IRepository<EventDevice>, IDisposable
    {
        protected readonly AppDatabaseContext _context;

        public TrackingEventDeviceRepository(AppDatabaseContext context) => _context = context;

        protected virtual IQueryable<EventDevice> EventDevices =>
            _context.EventDevices.Include(ed => ed.Rule2EventDevices).ThenInclude(r2ed => r2ed.Rule)
            .Include(ed => ed.BoolDeviceActions).ThenInclude(bdea => bdea.Device)
            .Include(ed => ed.EventDevice2EventActionDevices).ThenInclude(ed2ead => ed2ead.EventActionDevice);

        
        public virtual EventDevice this[int id] => EventDevices.FirstOrDefault(ed => ed.ID == id);

        public virtual EventDevice this[string sysName] => EventDevices.FirstOrDefault(ed => ed.SysName == sysName);

        public virtual EventDevice this[EventDevice item] => this[item.ID];

        public void Add(EventDevice item) => _context.Add(item);

        public bool Delete(int id)
        {
            var device = this[id];
            if (device != null) return Delete(device);
            else return false;
        }

        public bool Delete(EventDevice item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.EventDevices.Attach(item).State;
            }

            if (state == EntityState.Unchanged)
            {
                _context.EventDevices.Remove(item);
                return true;
            }
            else return false;
        }

        public void Save() => _context.SaveChanges();

        public bool Update(EventDevice item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.EventDevices.Attach(item).State;
            }

            if (state != EntityState.Detached && state != EntityState.Deleted)
            {
                _context.EventDevices.Update(item);
                return true;
            }
            else return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)EventDevices).GetEnumerator();

        public virtual IEnumerator<EventDevice> GetEnumerator() => EventDevices.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
