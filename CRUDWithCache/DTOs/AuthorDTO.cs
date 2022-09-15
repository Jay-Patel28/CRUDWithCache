namespace CRUDWithCache.DTOs
{
    public class AuthorDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public List<BookDTO>? Books { get; set; }
    }
}
