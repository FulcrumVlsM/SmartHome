using System.Collections.Generic;

namespace SmartHome.Data
{
    public interface IRepository<T> : IEnumerable<T>
    {
        T this[int id] { get; }

        T this[string sysName] { get; }
        
        void Add(T item);

        bool Update(T item);

        bool Delete(int id);

        bool Delete(T item);

        void Save();
    }
}
