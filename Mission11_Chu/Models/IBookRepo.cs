namespace Mission11_Chu.Models
{
    // Interface for a repository to access books
    public interface IBookRepo
    {
        // Property to get a queryable collection of books
        public IQueryable<Book> Books { get; }
    }
}
