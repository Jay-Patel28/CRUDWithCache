namespace CRUDWithCache.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Price { get; set; }
        public List<Author> Authors { get; set; }
    }
}
