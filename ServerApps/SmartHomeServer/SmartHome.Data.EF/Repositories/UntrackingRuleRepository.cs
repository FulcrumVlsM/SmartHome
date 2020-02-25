using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System;
using System.Linq;

namespace SmartHome.Data.EF.Repositories
{
    public class UntrackingRuleRepository : TrackingRuleRepository, IDisposable
    {
        public UntrackingRuleRepository(AppDatabaseContext context) : base(context) { }

        protected override IQueryable<Rule> Rules =>
            _context.Rules.AsNoTracking().Include(r => r.Nodes).ThenInclude(rn => rn.BoolSensorConditions)
            .Include(r => r.Nodes).ThenInclude(rn => rn.NumericSensorConditions)
            .Include(r => r.Nodes).ThenInclude(rn => rn.TimeConditions)
            .Include(r => r.Nodes).ThenInclude(rn => rn.UserConditions)
            .Include(r => r.Rule2BoolActionDevices).ThenInclude(r2bad => r2bad.Device)
            .Include(r => r.Rule2EventDevices).ThenInclude(r2ed => r2ed.Device);

        public void Dispose() => _context.Dispose();
    }
}
