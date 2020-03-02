using Microsoft.EntityFrameworkCore;
using System.Linq;
using SmartHome.Data.Models;
using System;

namespace SmartHome.Data.EF.Repositories
{
    public class UntrackingBoolActionDeviceRepository : TrackingBoolActionDeviceRepository, IDisposable
    {
        public UntrackingBoolActionDeviceRepository(AppDatabaseContext context) : base(context) { }

        protected override IQueryable<BoolActionDevice> BoolActionDevices =>
            _context.BoolActionDevices.AsNoTracking()
            .Include(bad => bad.Rule2BoolActionDevices).ThenInclude(r2dad => r2dad.Rule)
            .Include(bad => bad.EventActions).ThenInclude(bdea => bdea.EventDevice);

        public void Dispose() => _context.Dispose();
    }
}
