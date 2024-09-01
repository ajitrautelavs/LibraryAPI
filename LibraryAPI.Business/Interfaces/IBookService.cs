using LibraryAPI.Models.Domain;

namespace LibraryAPI.Business.Interfaces
{
    public interface IBookService
    {
        Task<List<BookWithId>> GetAllBooksAsync(string searchString = "", string sortBy = "id", int offset = 0, int setLimit = 10);
        Task<BookWithId?> GetBookAsync(int id);
        Task <BookWithId> UpdateBookAsync(BookWithId book);
        Task<BookWithId> AddBookAsync(BookWithId book);
    }
}
