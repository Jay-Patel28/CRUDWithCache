using AutoMapper;
using CRUDWithCache.Entities;
using CRUDWithCache.Exceptions;
using CRUDWithCache.Models;
using CRUDWithCache.Repositories;

namespace CRUDWithCache.Managers
{
    public class BooksManager
    {
        private readonly BooksRepository _booksRepository;
        private readonly AuthorsCache _authorsCache;
        private readonly IMapper _mapper;

        public BooksManager(BooksRepository booksRepository, AuthorsCache authorsCache, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _authorsCache = authorsCache;
            _mapper = mapper;
        }

        public List<Book> GetAllBooks()
        {
            List<BookEntity> entities = _booksRepository.GetAll();

            List<Book> models = _mapper.Map<List<Book>>(entities);

            return models;
        }

        public Book AddBook(Book model)
        {
            if(model.Price == null)
            {
                //model.Price = 200;
            }
            BookEntity entity = _mapper.Map<Book,BookEntity>(model);


            entity.RelatedAauthorOfBookEntities = new List<AuthorOfBookEntity>();
            entity.CreatedDate = DateTime.Now;

            foreach (Author author in model.Authors)
            {
                AuthorOfBookEntity authorOfBookEntity = new AuthorOfBookEntity();

                authorOfBookEntity.RelatedAuthorId = author.Id;
                _authorsCache.ClearById(author.Id);

                authorOfBookEntity.RelatedBook = entity;

                entity.RelatedAauthorOfBookEntities.Add(authorOfBookEntity);
            }

            BookEntity createdEntity = _booksRepository.Save(entity);

            return _mapper.Map<Book>(GetBook(createdEntity.Id));
        }

        public Book? GetBook(Guid id)
        {
            BookEntity? entity = _booksRepository.GetBookWithAuthors(id);
            if (entity == null)
            {
                throw new NotFoundException("book.not.found", string.Format("Did not find any book with id {0}", id.ToString()));
            }

            Book model = _mapper.Map<Book>(entity);
            model.Authors = new List<Author>();

            foreach (AuthorOfBookEntity authorOfBook in entity.RelatedAauthorOfBookEntities)
            {
                model.Authors.Add(_mapper.Map<Author>(authorOfBook.RelatedAuthor));
            }

            return model;
        }

        public List<Book>? GetBookByPrice(int price) {

            List<BookEntity>? entity = _booksRepository.GetBookByPrice(price);

            List<Book> books = _mapper.Map<List<Book>>(entity);

            return books;
        }


        public void DeleteById(Guid id)
        {
            BookEntity? entity = _booksRepository.GetBookWithAuthors(id);

            if (entity == null)
            {
                throw new NotFoundException("book.not.found", string.Format("Did not find any book with id {0}", id.ToString()));
            }

            foreach (AuthorOfBookEntity authorOfBook in entity.RelatedAauthorOfBookEntities)
            {
                _authorsCache.ClearById(authorOfBook.RelatedAuthorId);
            }

            _booksRepository.Delete(entity);
        }
    }
}
