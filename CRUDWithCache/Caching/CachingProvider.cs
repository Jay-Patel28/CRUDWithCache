using System.Text.Json;
using System.Text;

namespace CRUDWithCache.Caching
{
    public abstract class CachingProvider
    {
        public abstract void Remove(string key);

        public abstract void Set(string key, object data);

        public abstract string? Get(string key);

        public static byte[] ObjectToByteArray(object obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }

        public static string? ByteArrayToObject(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
