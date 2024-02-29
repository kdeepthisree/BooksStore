namespace BooksStore.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> BooksPublished { get; set; }
    }
}
