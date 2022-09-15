using CRUDWithCache.DTOs;
using CRUDWithCache.Exceptions;
using CRUDWithCache.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace CRUDWithCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            List<AuthorDTO> data = _authorsService.GetAllAuthors();

            return data;
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public AuthorDTO Get(Guid id)
        {
            AuthorDTO author = _authorsService.GetAuthor(id);
            if (author == null)
            {
                throw new NotFoundException("author.not.found", "Did not find an author with id " + id.ToString());
            }

            return author;
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public AuthorDTO Post([FromBody] AuthorDTO value)
        {
            return _authorsService.AddAuthor(value);
        }

        //// PUT api/<AuthorsController>/5
        //[HttpPut("{id}")]
        //public AuthorDTO Put(int id, [FromBody] AuthorDTO value)
        //{
        //}

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _authorsService.DeleteById(id);
        }
    }
}
