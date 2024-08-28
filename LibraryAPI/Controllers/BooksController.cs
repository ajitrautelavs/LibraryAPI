using LibraryAPI.Business.Interfaces;
using LibraryAPI.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    /// <summary>
    /// Library API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        /// <summary>
        /// BooksController
        /// </summary>
        /// <param name="bookService"></param>
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<BookWithId>> GetAllBooks([FromQuery] string searchString = "", 
            [FromQuery] string sortBy = "id", 
            [FromQuery] int offset = 0, 
            [FromQuery] int setLimit = 10)
        {
            return Ok(_bookService.GetAllBooks(searchString, sortBy, offset, setLimit));
        }

        /// <summary>
        /// Get a specific book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<BookWithId> GetBook([FromRoute] int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<BookWithId> UpdateBook([FromRoute] int id, [FromBody] Book book)
        {
            var existingBook = _bookService.GetBook(id);
            if (existingBook == null)
                return NotFound();

            var bookWithId = new BookWithId
            {
                Id = existingBook.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate
            };

            _bookService.UpdateBook(bookWithId);
            return Ok(bookWithId);
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BookWithId> AddBook([FromBody] Book book)
        {
            var bookWithId = new BookWithId
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate
            };

            _bookService.AddBook(bookWithId);
            return CreatedAtAction(nameof(GetBook), new { id = bookWithId.Id}, bookWithId);
        }
    }
}
