namespace Mission11_Chu.Models.ViewModels
{
    // View model for displaying a list of books with pagination information
    public class BookListViewModel
    {
        // Initialize Bookslist with an empty collection to satisfy non-nullable requirement
        public IQueryable<Book> Bookslist{ get; set; } = Enumerable.Empty<Book>().AsQueryable();

        // PaginationInfo property to hold pagination information
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();

    }
}
