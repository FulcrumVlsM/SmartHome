using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class TrackingRuleRepository : IRepository<Rule>, IDisposable
    {
        protected readonly AppDatabaseContext _context;

        public TrackingRuleRepository(AppDatabaseContext context) => _context = context;


        protected virtual IQueryable<Rule> Rules =>
            _context.Rules.Include(r => r.Nodes).ThenInclude(rn => rn.BoolSensorConditions)
            .Include(r => r.Nodes).ThenInclude(rn => rn.NumericSensorConditions)
            .Include(r => r.Nodes).ThenInclude(rn => rn.TimeConditions)
            .Include(r => r.Nodes).ThenInclude(rn => rn.UserConditions)
            .Include(r => r.Rule2BoolActionDevices).ThenInclude(r2bad => r2bad.Device)
            .Include(r => r.Rule2EventDevices).ThenInclude(r2ed => r2ed.Device);

        
        public Rule this[int id] => Rules.FirstOrDefault(r => r.ID == id);

        public Rule this[string sysName] => throw new NotImplementedException("Элемент \"Rule\" не имеет поля \"SysName\"");

        public Rule this[Rule item] => this[item.ID];

        public void Add(Rule item) => _context.Rules.Add(item);

        public bool Delete(int id)
        {
            var rule = this[id];
            if (rule != null) return Delete(rule);
            else return false;
        }

        public bool Delete(Rule item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.Rules.Attach(item).State;
            }

            if (state == EntityState.Unchanged)
            {
                _context.Rules.Remove(item);
                return true;
            }
            else return false;
        }

        public void Save() => _context.SaveChanges();

        public bool Update(Rule item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.Rules.Attach(item).State;
            }

            if (state != EntityState.Detached && state != EntityState.Deleted)
            {
                _context.Rules.Update(item);
                return true;
            }
            else return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Rules).GetEnumerator();

        public IEnumerator<Rule> GetEnumerator() => Rules.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
