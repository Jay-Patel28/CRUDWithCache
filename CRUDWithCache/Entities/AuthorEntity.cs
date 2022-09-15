
namespace CRUDWithCache.Entities
{
    public class AuthorEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<AuthorOfBookEntity> RelatedAauthorOfBookEntities { get; set; }
    }
}
