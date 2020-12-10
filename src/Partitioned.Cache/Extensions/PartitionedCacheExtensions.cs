using Microsoft.Extensions.DependencyInjection;
using Partitioned.Cache.Provider;
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

        public static IPartitionedCacheProvider WithPartition<T>(
            this IPartitionedCacheProvider partitionedCacheProvider,
            string key)
        {
            if (partitionedCacheProvider == null)
            {
                throw new ArgumentNullException("The partitionedCacheProvider cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("The key cannot be null, empty or white space.");
            }

            if (!partitionedCacheProvider.TryAddPartition<T>(key))
            {
                throw new InvalidOperationException($"Unable to add the partition with key - {key}");
            }

            return partitionedCacheProvider;
        }
    }
}
