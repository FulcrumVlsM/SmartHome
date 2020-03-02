using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class NumericSensorHistoryRepository : IHistoryRepository<NumericSensorHistoryItem>, IDisposable
    {
        private readonly AppDatabaseContext _context;

        public NumericSensorHistoryRepository(AppDatabaseContext context) => _context = context;


        private IQueryable<NumericSensorHistoryItem> History => _context.NumericSensorHistory.AsNoTracking();

        public Type ElementType => History.ElementType;

        public Expression Expression => History.Expression;

        public IQueryProvider Provider => History.Provider;

        public void Add(NumericSensorHistoryItem item) => _context.NumericSensorHistory.Add(item);

        public void Save() => _context.SaveChanges();

        IEnumerator IEnumerable.GetEnumerator() => History.GetEnumerator();

        public IEnumerator<NumericSensorHistoryItem> GetEnumerator() => History.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
