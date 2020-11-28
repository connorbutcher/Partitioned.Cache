using Microsoft.Extensions.Caching.Memory;

namespace Partitioned.Cache.Provider
{
    public interface IPartitionedCacheProvider
    {
        bool TryAddPartition<T>(string key, MemoryCacheOptions memoryCacheOptions = null);

        IPartitionedCache<T> Resolve<T>(string key);
    }
}
