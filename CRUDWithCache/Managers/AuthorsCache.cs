using CRUDWithCache.Caching;
using CRUDWithCache.Models;
using System.Text.Json;

namespace CRUDWithCache.Managers
{
    public class AuthorsCache
    {
        private readonly string ALL_AUTHORS = "ALL_AUTHORS";
        private readonly string AUTHOR = "AUTHOR_";

        private readonly CachingProvider _cache;

        public AuthorsCache(ServiceResolver serviceResolver)
        {
            _cache = serviceResolver(CacheType.InMemoryCache);
        }

        public void ClearAllAuthors()
        {
            _cache.Remove(ALL_AUTHORS);
        }

        public List<Author>? GetAllAuthors()
        {
            string cacheValue = _cache.Get(ALL_AUTHORS);

            return cacheValue == null ? null : JsonSerializer.Deserialize<List<Author>>(cacheValue);
        }

        public void SetAllAuthors(List<Author> models)
        {
            _cache.Set(ALL_AUTHORS, models);
        }

        public Author? GetById(Guid id)
        {
            string cacheValue = _cache.Get(AUTHOR + id.ToString());

            return cacheValue == null ? null : JsonSerializer.Deserialize<Author>(cacheValue);
        }

        public void SetById(Guid id, Author value)
        {
            _cache.Set(AUTHOR + id.ToString(), value);
        }

        public void ClearById(Guid id)
        {
            _cache.Remove(AUTHOR + id.ToString());
        }
    }
}
