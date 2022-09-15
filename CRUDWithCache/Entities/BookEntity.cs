using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CRUDWithCache.Entities
{
    [Index(nameof(Price), Name ="PRICE")]
    public class BookEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<AuthorOfBookEntity> RelatedAauthorOfBookEntities { get; set; }
    }
}
