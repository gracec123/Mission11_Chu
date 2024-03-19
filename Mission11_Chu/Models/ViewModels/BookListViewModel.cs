namespace Mission11_Chu.Models.ViewModels
{
    public class BookListViewModel
    {
        public IQueryable<Book> Bookslist{ get; set; }

        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();

    }
}
