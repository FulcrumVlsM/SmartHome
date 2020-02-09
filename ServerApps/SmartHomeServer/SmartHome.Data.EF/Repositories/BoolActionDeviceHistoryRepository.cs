using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class BoolActionDeviceHistoryRepository : IHistoryRepository<BoolActionDeviceHistory>
    {
        private AppDatabaseContext _context;

        public BoolActionDeviceHistoryRepository(AppDatabaseContext context) => _context = context;

        private IQueryable<BoolActionDeviceHistory> History => _context.BoolActionDeviceHistory.AsNoTracking();


        public Type ElementType => History.ElementType;

        public Expression Expression => History.Expression;

        public IQueryProvider Provider => History.Provider;

        public void Add(BoolActionDeviceHistory item) => _context.BoolActionDeviceHistory.Add(item);

        public void Save() => _context.SaveChanges();

        IEnumerator IEnumerable.GetEnumerator() => History.GetEnumerator();

        public IEnumerator<BoolActionDeviceHistory> GetEnumerator() => History.GetEnumerator();
    }
}
