using Microsoft.AspNetCore.Mvc;
using Partitioned.Cache.Provider;
using System.Threading.Tasks;

namespace Partitioned.Cache.Sample.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        private readonly IPartitionedCacheProvider _partitionedCacheProvider;
        private readonly IPartitionedCache<string> _usersCache;
        private readonly IPartitionedCache<int> _usersIdCache;

        public TestController(IPartitionedCacheProvider partitionedCacheProvider)
        {
            _partitionedCacheProvider = partitionedCacheProvider;

            _usersCache = _partitionedCacheProvider.Resolve<string>("Users Cache");
            _usersIdCache = _partitionedCacheProvider.Resolve<int>("UserId Cache");
        }

        [HttpGet("data")]
        public async Task<ActionResult> GetData()
        {
            var result = await _usersCache.GetOrCreateAsync(1, async (cacheEntry) => await Task.FromResult("test"));

            return Ok(result);
        }

        [HttpGet("data2")]
        public async Task<ActionResult> GetData2()
        {
            var result = await _usersCache.GetOrCreateAsync(1, async (cacheEntry) => await Task.FromResult("test2"));

            return Ok(result);
        }
    }
}
