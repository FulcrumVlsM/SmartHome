using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System.Linq;

namespace SmartHome.Data.EF.Repositories
{
    class UntrackingNumericSensorRepository : TrackingNumericSensorRepository
    {
        public UntrackingNumericSensorRepository(AppDatabaseContext context) : base(context) { }

        protected override IQueryable<NumericSensor> NumericSensors =>
            _context.NumericSensors.AsNoTracking().Include(ns => ns.Conditions).ThenInclude(nsc => nsc.Node);
    }
}
