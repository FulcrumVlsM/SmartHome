using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System;
using System.Linq;

namespace SmartHome.Data.EF.Repositories
{
    public class UntrackingNumericSensorRepository : TrackingNumericSensorRepository, IDisposable
    {
        public UntrackingNumericSensorRepository(AppDatabaseContext context) : base(context) { }

        protected override IQueryable<NumericSensor> NumericSensors =>
            _context.NumericSensors.AsNoTracking().Include(ns => ns.Conditions).ThenInclude(nsc => nsc.Node);

        public void Dispose() => _context.Dispose();
    }
}
