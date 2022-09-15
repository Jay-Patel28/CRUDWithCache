namespace CRUDWithCache.Entities
{
    public class AuthorOfBookEntity : BaseEntity
    {
        public Guid RelatedAuthorId { get; set; }
        public AuthorEntity RelatedAuthor { get; set; }

        public Guid RelatedBookId { get; set; }
        public BookEntity RelatedBook { get; set; }
    }
}
