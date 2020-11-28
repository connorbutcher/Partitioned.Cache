using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace Partitioned.Cache.Provider
{
    public sealed class PartitionedCacheProvider : IPartitionedCacheProvider
    {
        public PartitionedCacheProvider()
        {
            CachePartitions = new Dictionary<string, object>();
        }

        public IPartitionedCache<T> Resolve<T>(string key)
        {
            if (!CachePartitions.TryGetValue(key, out var partitionedCache))
            {
                // TODO: throw.
            }

            return (IPartitionedCache<T>)partitionedCache;
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

        private IDictionary<string, object> CachePartitions { get; }
    }
}
