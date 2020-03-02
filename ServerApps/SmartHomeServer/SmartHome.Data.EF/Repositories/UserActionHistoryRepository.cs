using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class UserActionHistoryRepository : IHistoryRepository<UserActionHistoryItem>, IDisposable
    {
        private readonly AppDatabaseContext _context;

        public UserActionHistoryRepository(AppDatabaseContext context) => _context = context;


        private IQueryable<UserActionHistoryItem> History => _context.UserActionHistory.AsNoTracking()
            .Include(uah => uah.SmartCard).Include(uah => uah.User);

        public Type ElementType => History.ElementType;

        public Expression Expression => History.Expression;

        public IQueryProvider Provider => History.Provider;

        public void Add(UserActionHistoryItem item) => _context.UserActionHistory.Add(item);

        public void Save() => _context.SaveChanges();

        IEnumerator IEnumerable.GetEnumerator() => History.GetEnumerator();

        public IEnumerator<UserActionHistoryItem> GetEnumerator() => History.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
