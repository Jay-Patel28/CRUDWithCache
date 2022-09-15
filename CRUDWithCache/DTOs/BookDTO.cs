namespace CRUDWithCache.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        //public int? Price { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
