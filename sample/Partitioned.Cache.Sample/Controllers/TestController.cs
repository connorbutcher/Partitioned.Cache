using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Partitioned.Cache.Sample.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        private readonly IPartitionedCache<string> _stringCache;
        private readonly IPartitionedCache<int> _intCache;
        private readonly IPartitionedCache<string> _stringCache2;
        private readonly IPartitionedCacheProvider _partitionedCacheProvider;

        public TestController(IPartitionedCache<string> stringCache,
            IPartitionedCache<string> stringCache2,
            IPartitionedCache<int> intCache,
            IPartitionedCacheProvider partitionedCacheProvider)
        {
            _stringCache = stringCache;
            _intCache = intCache;
            _stringCache2 = stringCache2;
            _partitionedCacheProvider = partitionedCacheProvider;
        }

        [HttpGet("data")]
        public async Task<ActionResult> GetData()
        {
            var result = await _stringCache.GetOrCreateAsync(1, async (cacheEntry) => await Task.FromResult("test"));

            return Ok(result);
        }

        [HttpGet("data2")]
        public async Task<ActionResult> GetData2()
        {
            var result = await _stringCache2.GetOrCreateAsync(1, async (cacheEntry) => await Task.FromResult("test2"));

            return Ok(result);
        }
    }
}
