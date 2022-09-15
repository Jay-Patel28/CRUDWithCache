using CRUDWithCache.DTOs;
using CRUDWithCache.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class checkOnly : ControllerBase
    {
        [HttpGet]
        public string GetAllAuthors()
        {
            
            return "Home";
        }

        [HttpGet("/persons")]
        public string GetAllPersons()
        {

            return "Persons Here";
        }

        [HttpGet("/person/{pId:range(20,40)}")]
        public string GetPerson(int pId)
        {
            
            return $"Persons {Request.Path.Value.ToString()}";
        }


    }
}
