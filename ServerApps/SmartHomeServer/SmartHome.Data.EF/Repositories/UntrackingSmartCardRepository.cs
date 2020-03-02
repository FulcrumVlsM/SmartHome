using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System;
using System.Linq;

namespace SmartHome.Data.EF.Repositories
{
    public class UntrackingSmartCardRepository : TrackingSmartCardRepository, IDisposable
    {
        public UntrackingSmartCardRepository(AppDatabaseContext context) : base(context) { }


        protected override IQueryable<SmartCard> SmartCards =>
            _context.SmartCards.AsNoTracking().Include(sc => sc.User);

        public void Dispose() => _context.Dispose();
    }
}
