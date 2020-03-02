using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class BoolSensorHistoryRepository : IHistoryRepository<BoolSensorHistoryItem>, IDisposable
    {
        private readonly AppDatabaseContext _context;

        public BoolSensorHistoryRepository(AppDatabaseContext context) => _context = context;

        private IQueryable<BoolSensorHistoryItem> History => _context.BoolSensorHistory.AsNoTracking();


        public Type ElementType => History.ElementType;

        public Expression Expression => History.Expression;

        public IQueryProvider Provider => History.Provider;

        public void Add(BoolSensorHistoryItem item) => _context.BoolSensorHistory.Add(item);

        public void Save() => _context.SaveChanges();

        IEnumerator IEnumerable.GetEnumerator() => History.GetEnumerator();

        public IEnumerator<BoolSensorHistoryItem> GetEnumerator() => History.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
