using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System.Linq;

namespace SmartHome.Data.EF.Repositories
{
    class UntrackingSmartCardRepository : TrackingSmartCardRepository
    {
        public UntrackingSmartCardRepository(AppDatabaseContext context) : base(context) { }


        protected override IQueryable<SmartCard> SmartCards =>
            _context.SmartCards.AsNoTracking().Include(sc => sc.User);
    }
}
