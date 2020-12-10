using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;

namespace Partitioned.Cache
{
    public sealed class PartitionedCache<T> : IPartitionedCache<T>
    {
        private bool disposedValue;
        private readonly IMemoryCache _memoryCache;

        public PartitionedCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetOrCreateAsync(object key, Func<ICacheEntry, Task<T>> func)
        {
            return await _memoryCache.GetOrCreateAsync(key, func);
        }

        public bool TryGetValue(object key, out T value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public ICacheEntry CreateEntry(object key)
        {
            return _memoryCache.CreateEntry(key);
        }

        public void Remove(object key)
        {
            _memoryCache.Remove(key);
        }

        public T GetItem (object key)
        {
            return _memoryCache.Get<T>(key);
        }

        public T Set(T value, object key)
        {
            return _memoryCache.Set(key, value);
        }

        public T Set(T value, object key, MemoryCacheEntryOptions memoryCacheEntryOptions)
        {
            return _memoryCache.Set(key, value, memoryCacheEntryOptions);
        }

        public T Set(T value, object key, IChangeToken changeToken)
        {
            return _memoryCache.Set(key, value, changeToken);
        }

        public T Set(T value, object key, DateTimeOffset absoluteExpiration)
        {
            return _memoryCache.Set(key, value, absoluteExpiration);
        }

        public T Set(T value, object key, TimeSpan absoluteExpirationRelativeToNow)
        {
            return _memoryCache.Set(key, value, absoluteExpirationRelativeToNow);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
