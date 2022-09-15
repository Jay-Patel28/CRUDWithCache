using Microsoft.Extensions.Caching.Distributed;

namespace CRUDWithCache.Caching
{
    public class RedisCache : CachingProvider
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public override string? Get(string key)
        {
            byte[] bytes = _distributedCache.Get(key);

            if (bytes == null)
            {
                return null;
            }

            return ByteArrayToObject(bytes);
        }

        public override void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public override void Set(string key, object data)
        {
            if (data != null)
            {
                _distributedCache.Set(key, ObjectToByteArray(data));
            }
        }

    }
}
