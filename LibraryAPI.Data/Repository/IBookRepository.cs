using LibraryAPI.Models.Domain;

namespace LibraryAPI.Data.Repository
{
    public interface IBookRepository
    {
        Task<List<BookWithId>> GetAll(string searchString = "", string sortBy = "id", int offset = 0, int setLimit = 10);
        Task<BookWithId?> GetById(int id);
        Task<BookWithId> Add(BookWithId entity);
        Task Update(BookWithId entity);
    }
}
