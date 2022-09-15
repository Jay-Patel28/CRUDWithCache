using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace CRUDWithCache.Caching
{
    public class InMemoryCache : CachingProvider
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public override string? Get(string key)
        {
            byte[] bytes = (byte[])_memoryCache.Get(key);

            if (bytes == null)
            {
                return null;
            }

            return ByteArrayToObject(bytes);
        }

        public override void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public override void Set(string key, object data)
        {
            if (data != null)
            {
                _memoryCache.Set(key, ObjectToByteArray(data));
            }
        }
    }
}
