using LibraryAPI.Models.Domain;

namespace LibraryAPI.Business.Interfaces
{
    public interface IBookService
    {
        List<BookWithId> GetAllBooks();
        BookWithId? GetBook(int id);
        BookWithId UpdateBook(BookWithId book);
        BookWithId AddBook(BookWithId book);
    }
}
