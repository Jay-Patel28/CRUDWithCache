using AutoMapper;
using CRUDWithCache.Managers;
using CRUDWithCache.Models;
using CRUDWithCache.DTOs;

namespace CRUDWithCache.Services
{
    public class BooksService
    {
        private readonly BooksManager _booksManager;
        private readonly IMapper _mapper;

        public BooksService(BooksManager booksManager, IMapper mapper)
        {
            _booksManager = booksManager;
            _mapper = mapper;
        }

        public List<BookDTO> GetAllBooks()
        {
            List<Book> models = _booksManager.GetAllBooks();

            return _mapper.Map<List<BookDTO>>(models);
        }

        public BookDTO AddBook(BookDTO value)
        {
            Book model = _mapper.Map<Book>(value);

            Book addedBook = _booksManager.AddBook(model);

            return _mapper.Map<BookDTO>(addedBook);
        }

        public BookDTO GetBook(Guid id)
        {
            Book? model = _booksManager.GetBook(id);

            if (model == null)
            {
                return null;
            }

            return _mapper.Map<BookDTO>(model);
        }

        public List<BookDTO> GetBookByPrice(int price)
        {
            List<Book>? model = _booksManager.GetBookByPrice(price);

            if (model == null)
            {
                return null;
            }

            return _mapper.Map<List<BookDTO>>(model);
        }

        public void DeleteById(Guid id)
        {
            _booksManager.DeleteById(id);
        }
    }
}
