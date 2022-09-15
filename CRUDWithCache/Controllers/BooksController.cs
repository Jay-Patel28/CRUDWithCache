using CRUDWithCache.DTOs;
using CRUDWithCache.Managers;
using CRUDWithCache.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDWithCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<BookDTO> GetAllBooks()
        {
            return _booksService.GetAllBooks();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public BookDTO Get(Guid id)
        {
            return _booksService.GetBook(id);
        }

        [HttpGet("price/{price}")]
        public List<BookDTO> Get(int price)
        {
            return _booksService.GetBookByPrice(price);
        }

        // POST api/<BooksController>
        [HttpPost]
        public BookDTO Post([FromBody] BookDTO value)
        {
            return _booksService.AddBook(value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _booksService.DeleteById(id);
        }
    }
}
