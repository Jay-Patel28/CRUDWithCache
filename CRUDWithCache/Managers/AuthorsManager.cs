using AutoMapper;
using CRUDWithCache.Entities;
using CRUDWithCache.Exceptions;
using CRUDWithCache.Models;
using CRUDWithCache.Repositories;

namespace CRUDWithCache.Managers
{
    public class AuthorsManager
    {
        private readonly AuthorsRepository _authorsRepository;
        private readonly AuthorsCache _authorsCache;
        private readonly IMapper _mapper;

        public AuthorsManager(AuthorsRepository authorsRepository, AuthorsCache authorsCache, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _authorsCache = authorsCache;
            _mapper = mapper;
        }

        public List<Author> GetAllAuthors()
        {
            List<Author>? models = _authorsCache.GetAllAuthors();

            if (models == null)
            {
                List<AuthorEntity> entities = _authorsRepository.GetAll();

                models = _mapper.Map<List<Author>>(entities);

                _authorsCache.SetAllAuthors(models);
            }

            return models;
        }

        public Author AddAuthor(Author author)
        {
            _authorsCache.ClearAllAuthors();

            AuthorEntity entity = _mapper.Map<AuthorEntity>(author);

            AuthorEntity createdEntity = _authorsRepository.Save(entity);

            return _mapper.Map<Author>(createdEntity);
        }

        public Author? GetAuthor(Guid id)
        {
            Author? model = _authorsCache.GetById(id);

            if (model == null)
            {
                AuthorEntity? entity = _authorsRepository.GetWithBooks(id);

                if (entity == null) { return null; }

                model = _mapper.Map<Author>(entity);

                model.Books = new List<Book>();
                foreach (AuthorOfBookEntity authorOfBook in entity.RelatedAauthorOfBookEntities)
                {
                    model.Books.Add(_mapper.Map<Book>(authorOfBook.RelatedBook));
                }

                _authorsCache.SetById(id, model);
            }

            return model;
        }

        public void DeleteById(Guid id)
        {
            int bookCount = _authorsRepository.GetBookCount(id);

            if (bookCount > 0)
            {
                throw new BadRequestException("author.has.books", string.Format("Please delete the books authored by {0} before deleting it.", id.ToString()));
            }


            _authorsRepository.DeleteById(id);

            _authorsCache.ClearAllAuthors();
            _authorsCache.ClearById(id);
        }
    }
}
