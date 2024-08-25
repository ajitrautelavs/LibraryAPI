using LibraryAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<BookWithId> Add(BookWithId entity)
        {
            var newEntity = _libraryDbContext.Books.Attach(entity);
            await _libraryDbContext.SaveChangesAsync();

            return newEntity.Entity;
        }

        public async Task<IEnumerable<BookWithId>> GetAll()
        {
            return await _libraryDbContext.Books.ToListAsync();
        }

        public async Task<BookWithId?> GetById(int id)
        {
            var entity = await _libraryDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
           
        }

        public async Task Update(BookWithId entity)
        {
            _libraryDbContext.ChangeTracker.Clear();
            _libraryDbContext.Books.Attach(entity);
            _libraryDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _libraryDbContext.SaveChangesAsync();
        }
    }
}
