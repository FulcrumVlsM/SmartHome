using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class EventDeviceHistoryRepository : IHistoryRepository<EventDeviceHistory>, IDisposable
    {
        private readonly AppDatabaseContext _context;

        public EventDeviceHistoryRepository(AppDatabaseContext context) => _context = context;


        private IQueryable<EventDeviceHistory> History => _context.EventDeviceHistory.AsNoTracking();

        public Type ElementType => History.ElementType;

        public Expression Expression => History.Expression;

        public IQueryProvider Provider => History.Provider;

        public void Add(EventDeviceHistory item) => _context.EventDeviceHistory.Add(item);

        public void Save() => _context.SaveChanges();

        IEnumerator IEnumerable.GetEnumerator() => History.GetEnumerator();

        public IEnumerator<EventDeviceHistory> GetEnumerator() => History.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
