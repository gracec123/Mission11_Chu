
namespace Mission11_Chu.Models
{
    // Repository class for accessing books using Entity Framework
    public class EFBookRepo : IBookRepo
    {
        private BookstoreContext _context;

        // Constructor to initialize the repository with a BookstoreContext instance
        public EFBookRepo(BookstoreContext temp) {
            _context = temp;    
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
