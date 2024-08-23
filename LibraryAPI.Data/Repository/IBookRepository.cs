using LibraryAPI.Models.Domain;

namespace LibraryAPI.Data.Repository
{
    public interface IBookRepository
    {
        IEnumerable<BookWithId> GetAll();
        BookWithId? GetById(int id);
        BookWithId Add(BookWithId entity);
        void Update(BookWithId entity);
    }
}
