using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace Partitioned.Cache
{
    public sealed class PartitionedCacheProvider : IPartitionedCacheProvider
    {
        public PartitionedCacheProvider()
        {
            CachePartitions = new Dictionary<string, PartitionedCacheBase>();
        }

        public bool TryAddPartition<T>(string key, MemoryCacheOptions memoryCacheOptions = null)
        {
            if (CachePartitions.TryGetValue(key, out _))
            {
                return false;
            }

            if (memoryCacheOptions == null)
            {
                CachePartitions.Add(key, new PartitionedCache<T>(new MemoryCache(new MemoryCacheOptions())));
            }
            else
            {
                CachePartitions.Add(key, new PartitionedCache<T>(new MemoryCache(memoryCacheOptions)));
            }

            return true;
        }

        public IDictionary<string, PartitionedCacheBase> CachePartitions { get; }
    }
}
