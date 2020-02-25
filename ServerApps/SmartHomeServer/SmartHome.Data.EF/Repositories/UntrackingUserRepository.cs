using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Repositories
{
    public class UntrackingUserRepository : IRepository<User>, IDisposable
    {
        protected readonly AppDatabaseContext _context;

        public UntrackingUserRepository(AppDatabaseContext context) => _context = context;


        protected virtual IQueryable<User> Users =>
            _context.Users.AsNoTracking().Include(u => u.Conditions).ThenInclude(uc => uc.Node)
            .Include(u => u.SmartCards);
        
        public User this[int id] => Users.FirstOrDefault(u => u.ID == id);

        public User this[string sysName] => throw new NotImplementedException("Элемент \"User\" не имеет поля sysName");

        public User this[User item] => this[item.ID];

        public void Add(User item) => _context.Users.Add(item);

        public bool Delete(int id)
        {
            var user = this[id];
            if (user != null) return Delete(user);
            else return false;
        }

        public bool Delete(User item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.Users.Attach(item).State;
            }

            if (state == EntityState.Unchanged)
            {
                _context.Users.Remove(item);
                return true;
            }
            else return false;
        }

        public void Save() => _context.SaveChanges();

        public bool Update(User item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            EntityState state = _context.Entry(item).State;

            if (state == EntityState.Detached)
            {
                state = _context.Users.Attach(item).State;
            }

            if (state != EntityState.Detached && state != EntityState.Deleted)
            {
                _context.Users.Update(item);
                return true;
            }
            else return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Users).GetEnumerator();

        public IEnumerator<User> GetEnumerator() => Users.GetEnumerator();

        public void Dispose() => _context.Dispose();
    }
}
