using LibraryAPI.Business.Interfaces;
using LibraryAPI.Data.Repository;
using LibraryAPI.Models.Domain;

namespace LibraryAPI.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookWithId AddBook(BookWithId book)
        {
            _bookRepository.Add(book);
            return book;
        }

        public List<BookWithId> GetAllBooks(string searchString = "", string sortBy = "id", int offset = 0, int setLimit = 10)
        {
            return _bookRepository.GetAll(searchString, sortBy, offset, setLimit).Result.ToList();
        }

        public BookWithId? GetBook(int id)
        {
            return _bookRepository.GetById(id).Result;
        }

        public BookWithId UpdateBook(BookWithId book)
        {
            _bookRepository.Update(book);
            return book;
        }
    }
}
