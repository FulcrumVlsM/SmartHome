using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public sealed class UntrackingBoolSensorRepository : TrackingBoolSensorRepository
    {
        public UntrackingBoolSensorRepository(AppDatabaseContext context) : base(context) { }


        protected override IQueryable<BoolSensor> BoolSensors => _context.BoolSensors.AsNoTracking()
            .Include(bs => bs.Conditions).ThenInclude(bsc => bsc.Node);
    }
}
