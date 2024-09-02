using LibraryAPI.Authentication;
using LibraryAPI.Business.Interfaces;
using LibraryAPI.Models.Domain;
using LibraryAPI.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    /// <summary>
    /// Library API
    /// </summary>
    [Route("books")]
    [ApiKey]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        /// <summary>
        /// BooksController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="bookService"></param>
        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <remarks>Retrieve a list of all books in the library.</remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<BookWithId>>> GetBooks([FromQuery] string searchString = "", 
            [FromQuery] string sortBy = "id", 
            [FromQuery] int offset = 0, 
            [FromQuery] int setLimit = 10)
        {
            try
            {
                // Validate query values
                if (ObjectHasProperty.HasProperty(new BookWithId(), sortBy) == false)
                    throw new Exception("Sorting field " + sortBy + " is invalid");
                if (offset < 0)
                    throw new Exception("Offset must be a positive integer");
                if (setLimit < 1)
                    throw new Exception("SetLimit must be a positive integer");

                var list = await _bookService.GetAllBooksAsync(searchString, sortBy, offset, setLimit);
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured. {0}", ex.Message);
                return UnprocessableEntity("Error occured. " + ex.Message);
            }
        }

        /// <summary>
        /// Get a specific book
        /// </summary>
        /// <remarks>Retrieve a specific book by its ID.</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<BookWithId>> GetBook([FromRoute] int id)
        {
            try
            {

                var book = await _bookService.GetBookAsync(id);
                if (book == null)
                    return NotFound();

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured. {0}", ex.Message);
                return UnprocessableEntity("Error occured. " + ex.Message);
            }
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <remarks>Update an existing book by its ID.</remarks>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<BookWithId>> PutBook([FromRoute] int id, [FromBody] Book book)
        {
            try
            {
                var existingBook = await _bookService.GetBookAsync(id);
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

                var updatedBook = await _bookService.UpdateBookAsync(bookWithId);
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured. {0}", ex.Message);
                return UnprocessableEntity("Error occured. " + ex.Message);
            }
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <remarks>Add a new book to the library.</remarks>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BookWithId>> PostBook([FromBody] Book book)
        {
            try
            {
                var bookWithId = new BookWithId
                {
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    PublishedDate = book.PublishedDate
                };

                var addedBook = await _bookService.AddBookAsync(bookWithId);
                //return Ok(addedBook);
                return CreatedAtAction(nameof(GetBook), new { id = bookWithId.Id }, addedBook);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured. {0}", ex.Message);
                return UnprocessableEntity("Error occured. " + ex.Message);
            }
        }
    }
}
