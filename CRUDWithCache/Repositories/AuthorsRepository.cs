using CRUDWithCache.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithCache.Repositories
{
    public class AuthorsRepository
    {
        private readonly LibraryContext _dBContext;

        public AuthorsRepository(LibraryContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<AuthorEntity> GetAll()
        {
            return _dBContext.Authors.ToList();
        }

        public AuthorEntity Save(AuthorEntity entity)
        {
            _dBContext.Authors.Add(entity);

            _dBContext.SaveChanges();

            return entity;
        }

        public AuthorEntity? GetWithBooks(Guid id)
        {
            return _dBContext.Authors.Where(author => author.Id == id)
                            .Include(author => author.RelatedAauthorOfBookEntities).ThenInclude(bookAuthor => bookAuthor.RelatedBook)
                            .FirstOrDefault();
        }

        public void DeleteById(Guid id)
        {
            AuthorEntity entity = new() { Id = id };

            _dBContext.Attach(entity);
            _dBContext.Remove(entity);

            _dBContext.SaveChanges();
        }

        public int GetBookCount(Guid id)
        {
            return _dBContext.AuthorsOfBooks.Count(x => x.RelatedAuthorId == id);
        }
    }
}
