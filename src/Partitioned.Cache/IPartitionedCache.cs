using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Partitioned.Cache
{
    public interface IPartitionedCache<T>
    {
        Task<T> GetOrCreateAsync(object key, Func<ICacheEntry, Task<T>> func);
    }
}
