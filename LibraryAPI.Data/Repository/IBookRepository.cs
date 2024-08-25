using LibraryAPI.Models.Domain;

namespace LibraryAPI.Data.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookWithId>> GetAll();
        Task<BookWithId?> GetById(int id);
        Task<BookWithId> Add(BookWithId entity);
        Task Update(BookWithId entity);
    }
}
