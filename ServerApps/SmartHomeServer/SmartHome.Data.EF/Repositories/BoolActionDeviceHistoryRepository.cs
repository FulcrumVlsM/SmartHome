using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class BoolActionDeviceHistoryRepository : IHistoryRepository<BoolActionDeviceHistoryItem>, IDisposable
    {
        private AppDatabaseContext _context;

        public BoolActionDeviceHistoryRepository(AppDatabaseContext context) => _context = context;

        private IQueryable<BoolActionDeviceHistoryItem> History => _context.BoolActionDeviceHistory.AsNoTracking();


        public Type ElementType => History.ElementType;

        public Expression Expression => History.Expression;

        public IQueryProvider Provider => History.Provider;

        public void Add(BoolActionDeviceHistoryItem item) => _context.BoolActionDeviceHistory.Add(item);

        public void Save() => _context.SaveChanges();

        IEnumerator IEnumerable.GetEnumerator() => History.GetEnumerator();

        public IEnumerator<BoolActionDeviceHistoryItem> GetEnumerator() => History.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
