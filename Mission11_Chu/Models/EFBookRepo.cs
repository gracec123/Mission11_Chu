
namespace Mission11_Chu.Models
{
    public class EFBookRepo : IBookRepo
    {
        private BookstoreContext _context;
        public EFBookRepo(BookstoreContext temp) {
            _context = temp;    
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
