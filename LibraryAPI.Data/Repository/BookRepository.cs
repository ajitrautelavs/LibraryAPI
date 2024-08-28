using LibraryAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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

        public async Task<List<BookWithId>> GetAll(string searchString = "", string sortBy = "id", int offset = 0, int setLimit = 10)
        {
            return await GetAllBooks(searchString).OrderBy(sortBy).Skip(offset).Take(setLimit).ToListAsync();
        }

        private IQueryable<BookWithId> GetAllBooks(string searchString = "")
        {
            return _libraryDbContext.Books.Where(b => b.Title.Contains(searchString) | b.Author.Contains(searchString) | b.ISBN.Contains(searchString)).AsQueryable();
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
            _libraryDbContext.Entry(entity).State = EntityState.Modified;
            await _libraryDbContext.SaveChangesAsync();
        }
    }
}
