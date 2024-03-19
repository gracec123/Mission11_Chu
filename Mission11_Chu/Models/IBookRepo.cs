namespace Mission11_Chu.Models
{
    public interface IBookRepo
    {
        public IQueryable<Book> Books { get; }
    }
}
