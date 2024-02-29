namespace BooksStore.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        //naviagtion prop

        public List<Book_Author> Books_Authors { get; set; }
    }
}
