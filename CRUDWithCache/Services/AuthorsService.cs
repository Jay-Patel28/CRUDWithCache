using AutoMapper;
using CRUDWithCache.DTOs;
using CRUDWithCache.Managers;
using CRUDWithCache.Models;

namespace CRUDWithCache.Services
{
    public class AuthorsService
    {
        private readonly AuthorsManager _authorsManager;
        private readonly IMapper _mapper;

        public AuthorsService(AuthorsManager authorsManager, IMapper mapper)
        {
            _authorsManager = authorsManager;
            _mapper = mapper;
        }

        public List<AuthorDTO> GetAllAuthors()
        {
            List<Author> models = _authorsManager.GetAllAuthors();

            return _mapper.Map<List<AuthorDTO>>(models);
        }

        public AuthorDTO AddAuthor(AuthorDTO value)
        {
            Author author = _mapper.Map<Author>(value);

            Author addedAuthor = _authorsManager.AddAuthor(author);

            return _mapper.Map<AuthorDTO>(addedAuthor);
        }

        public AuthorDTO GetAuthor(Guid id)
        {
            Author? model = _authorsManager.GetAuthor(id);

            if (model == null) { return null; }

            return _mapper.Map<AuthorDTO>(model);
        }

        public void DeleteById(Guid id)
        {
            _authorsManager.DeleteById(id);
        }
    }
}
