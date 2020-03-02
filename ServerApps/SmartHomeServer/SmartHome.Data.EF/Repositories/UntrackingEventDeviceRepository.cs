using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class UntrackingEventDeviceRepository : TrackingEventDeviceRepository, IDisposable
    {
        public UntrackingEventDeviceRepository(AppDatabaseContext context) : base(context) { }

        protected override IQueryable<EventDevice> EventDevices =>
            _context.EventDevices.AsNoTracking().Include(ed => ed.Rule2EventDevices).ThenInclude(r2ed => r2ed.Rule)
            .Include(ed => ed.Actions).ThenInclude(bdea => bdea.Device);

        public void Dispose() => _context.Dispose();
    }
}
