using System.Collections.Generic;

namespace SmartHome.Data
{
    public interface IRepository<T> : IReadOnlyRepository<T>
    {
        bool Add(T item);

        bool Add(IEnumerable<T> items);

        void Update(T item);

        void Delete(T item);
    }
}
