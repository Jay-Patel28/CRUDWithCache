using CRUDWithCache.Entities;
using CRUDWithCache.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithCache.Repositories
{
    public class BooksRepository
    {
        private readonly LibraryContext _dBContext;

        public BooksRepository(LibraryContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<BookEntity> GetAll()
        {
            return _dBContext.Books.ToList();
        }

        public BookEntity Save(BookEntity entity)
        {
            
            _dBContext.Books.Add(entity);

            _dBContext.SaveChanges();

            return entity;
        }

        public BookEntity? GetBookWithAuthors(Guid id)
        {
            return _dBContext.Books.Where(book => book.Id == id)
                            .Include(book => book.RelatedAauthorOfBookEntities)
                            .ThenInclude(bookAuthor => bookAuthor.RelatedAuthor)
                            .FirstOrDefault();
        }


        public List<BookEntity>? GetBookByPrice(int price)
        {
            return _dBContext.Books.Where(book => book.Price >= price).OrderBy(book => book.Price)
                .Include(book => book.RelatedAauthorOfBookEntities)
                .ThenInclude(bookAuthor => bookAuthor.RelatedAuthor).ToList();
        }


        public void Delete(BookEntity entity)
        {
            _dBContext.Remove(entity);

            _dBContext.SaveChanges();
        }
    }
}
