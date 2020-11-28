using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Partitioned.Cache
{
    public sealed class PartitionedCache<T> : PartitionedCacheBase, IPartitionedCache<T>
    {
        private bool disposedValue;
        private readonly IMemoryCache _memoryCache;

        public PartitionedCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetOrCreateAsync(object key, Func<ICacheEntry, Task<T>> func)
        {
            var cacheKey = $"{typeof(T)}-{key}";

            return await _memoryCache.GetOrCreateAsync(cacheKey, func);
            //.AddPartition<User>("users")
            //    .AddPartition<User>("admin")
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PartitionedCache()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
