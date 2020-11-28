using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace Partitioned.Cache
{
    public interface IPartitionedCacheProvider
    {
        bool TryAddPartition<T>(string key, MemoryCacheOptions memoryCacheOptions = null);

        IDictionary<string, PartitionedCacheBase> CachePartitions { get; }
    }
}
