using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Partitioned.Cache.Extensions
{
    public static class PartitionedCacheExtensions
    {
        public static IPartitionedCacheProvider AddPartitionedCacheProvider(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();

            var partitionCacheProvider = new PartitionedCacheProvider();
            serviceCollection.AddSingleton<IPartitionedCacheProvider>(partitionCacheProvider);

            return partitionCacheProvider;
        }

        public static IPartitionedCacheProvider AddPartition(this IPartitionedCacheProvider partitionedCacheProvider, Type partitionType, string key)
        {
            partitionedCacheProvider.
        }

        public static IServiceProvider ConfigurePartitionedCacheProvider(this IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetService<IPartitionedCacheProvider>();
            var memCache = serviceProvider.GetService<IMemoryCache>();

            service.CachePartitions.Add(new PartitionedCache<string>(memCache));

            return serviceProvider;
        }
    }
}
