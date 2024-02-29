using BooksStore.Data.Service;
using BooksStore.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService _bookService;
        public BookController(BookService bookService) {
            _bookService = bookService;

        }

        [HttpGet("get-books")]
        public IActionResult GetBooks() { 
          var books = _bookService.GetBooks();
            return Ok(books);
        }


        [HttpGet("get-book-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var bookId = _bookService.GetbookById(id);
            return Ok(bookId);
        }

        //[HttpPost("PostBook")]
        //public ActionResult AddBook([FromBody]BooksVM book) 
        //{
        //    _bookService.AddBook(book);
        //    return Ok();
        //}



        [HttpPost("PostBook-with-Author")]
        public IActionResult AddBookWithAuthor([FromBody] BooksVM book)
        {
            _bookService.AddBookWithAuthor(book);
            return Ok();
        }

        [HttpPut("updateBook-by-id/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody]BooksVM  book) {
            var _bookupdate = _bookService.updateBookById(id, book);
            return Ok(_bookupdate);
        }


        [HttpDelete("delete-Book/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _bookService.deleteBook(id);
            return Ok();
        }
    }
}
