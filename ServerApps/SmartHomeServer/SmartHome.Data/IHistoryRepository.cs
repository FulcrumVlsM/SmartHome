using System;
using System.Linq;

namespace SmartHome.Data
{
    public interface IHistoryRepository<T> : IQueryable<T>
    {
        void Add(T item);

        void Save();
    }
}
