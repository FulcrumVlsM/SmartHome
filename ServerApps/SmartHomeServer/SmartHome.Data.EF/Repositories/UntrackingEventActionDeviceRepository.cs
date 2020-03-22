using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using System.Linq;

namespace SmartHome.Data.EF.Repositories
{
    public class UntrackingEventActionDeviceRepository : TrackingEventActionDeviceRepository
    {
        public UntrackingEventActionDeviceRepository(AppDatabaseContext context) : base(context) { }

        protected override IQueryable<EventActionDevice> EventActionDevices =>
            _context.EventActionDevices.AsNoTracking().Include(ead => ead.EventDevices2EventActionDevice)
            .ThenInclude(ed2ead => ed2ead.EventDevice);
    }
}
