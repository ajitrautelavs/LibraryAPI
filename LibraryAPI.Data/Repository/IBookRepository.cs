using LibraryAPI.Models.Domain;

namespace LibraryAPI.Data.Repository
{
    public interface IBookRepository
    {
        Task<List<BookWithId>> GetAllAsync(string searchString = "", string sortBy = "id", int offset = 0, int setLimit = 10);
        Task<BookWithId?> GetByIdAsync(int id);
        Task<BookWithId> AddAsync(BookWithId entity);
        Task UpdateAsync(BookWithId entity);
    }
}
