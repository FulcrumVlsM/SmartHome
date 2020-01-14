using System;
using System.Collections.Generic;

namespace SmartHome.Data
{
    public interface IReadOnlyRepository<T> : IEnumerable<T>
    {
        T Get(int id);
        
        IEnumerable<T> Get();

        IEnumerable<T> Get(Func<T, bool> predicate);
    }
}
