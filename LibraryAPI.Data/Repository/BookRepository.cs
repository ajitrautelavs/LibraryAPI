using LibraryAPI.Models.Domain;

namespace LibraryAPI.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public BookWithId Add(BookWithId entity)
        {
            var newEntity = _libraryDbContext.Books.Attach(entity);
            _libraryDbContext.SaveChanges();

            return newEntity.Entity;
        }

        public IEnumerable<BookWithId> GetAll()
        {
            return _libraryDbContext.Books;
        }

        public BookWithId? GetById(int id)
        {
            var entity = _libraryDbContext.Books.FirstOrDefault(x => x.Id == id);
            return entity;
           
        }

        public void Update(BookWithId entity)
        {
            _libraryDbContext.ChangeTracker.Clear();
            _libraryDbContext.Books.Attach(entity);
            _libraryDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _libraryDbContext.SaveChanges();
        }
    }
}
