using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class TrackingSmartCardRepository : IRepository<SmartCard>, IDisposable
    {
        protected readonly AppDatabaseContext _context;

        public TrackingSmartCardRepository(AppDatabaseContext context) => _context = context;


        protected virtual IQueryable<SmartCard> SmartCards =>
            _context.SmartCards.Include(sc => sc.User);
        
        public SmartCard this[int id] => SmartCards.FirstOrDefault(sc => sc.ID == id);

        public SmartCard this[string key] => SmartCards.FirstOrDefault(sc => sc.Key == key);

        public SmartCard this[SmartCard item] => this[item.ID];

        public void Add(SmartCard item) => _context.SmartCards.Add(item);

        public bool Delete(int id)
        {
            var device = this[id];
            if (device != null) return Delete(device);
            else return false;
        }

        public bool Delete(SmartCard item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.SmartCards.Attach(item).State;
            }

            if (state == EntityState.Unchanged)
            {
                _context.SmartCards.Remove(item);
                return true;
            }
            else return false;
        }

        public void Save() => _context.SaveChanges();

        public bool Update(SmartCard item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.SmartCards.Attach(item).State;
            }

            if (state != EntityState.Detached && state != EntityState.Deleted)
            {
                _context.SmartCards.Update(item);
                return true;
            }
            else return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)SmartCards).GetEnumerator();

        public IEnumerator<SmartCard> GetEnumerator() => SmartCards.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
