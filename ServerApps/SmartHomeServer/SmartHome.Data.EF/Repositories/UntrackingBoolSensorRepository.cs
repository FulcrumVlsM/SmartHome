using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public sealed class UntrackingBoolSensorRepository : TrackingBoolSensorRepository, IDisposable
    {
        public UntrackingBoolSensorRepository(AppDatabaseContext context) : base(context) { }


        protected override IQueryable<BoolSensor> BoolSensors => _context.BoolSensors.AsNoTracking()
            .Include(bs => bs.Conditions).ThenInclude(bsc => bsc.Node);

        public void Dispose() => _context.Dispose();
    }
}
