using LibraryAPI.Models.Domain;

namespace LibraryAPI.Business.Interfaces
{
    public interface IBookService
    {
        List<BookWithId> GetAllBooks(string searchString = "", string sortBy = "id", int offset = 0, int setLimit = 10);
        BookWithId? GetBook(int id);
        BookWithId UpdateBook(BookWithId book);
        BookWithId AddBook(BookWithId book);
    }
}
