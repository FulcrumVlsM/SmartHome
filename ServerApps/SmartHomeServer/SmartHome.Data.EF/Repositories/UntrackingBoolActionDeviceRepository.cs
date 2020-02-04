using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class UntrackingBoolActionDeviceRepository : TrackingBoolActionDeviceRepository, IEnumerable<BoolActionDevice>
    {
        public UntrackingBoolActionDeviceRepository(AppDatabaseContext context) : base(context) { }


        public override BoolActionDevice this[int id] => 
            _context.BoolActionDevices.AsNoTracking().FirstOrDefault(bad => bad.ID == id);

        public override BoolActionDevice this[string sysName] =>
            _context.BoolActionDevices.AsNoTracking().FirstOrDefault(bad => bad.SysName == sysName);



        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_context.BoolActionDevices.AsNoTracking()).GetEnumerator();

        public override IEnumerator<BoolActionDevice> GetEnumerator() =>
            _context.BoolActionDevices.AsNoTracking().GetEnumerator();
    }
}
