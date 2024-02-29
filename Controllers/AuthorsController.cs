using BooksStore.Data.Service;
using BooksStore.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]AuthorVM author)
        {
           _authorsService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-written-books/{AuthorId}")]
        public IActionResult GetBooksByAuthor(int AuthorId)
        {
            var response = _authorsService.GetAuthorwithBooks(AuthorId);
            return Ok(response);
        }
    }
}
