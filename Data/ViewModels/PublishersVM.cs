namespace BooksStore.Data.ViewModels
{
    public class PublishersVM
    {
        public string PublisherName { get; set; }
    }



    //books with Author
    public class PublisherWithBooksAndAuthorVM
    {
        public string PublisherName { get; set; }

        public List<BookAuthorsVM> oneBookAuthors { get; set; }

    }

    //one book can have multiple authord
    public class BookAuthorsVM
    {
        public string BookName { get; set; }

        public List<String> OneBookAuthors { get; set;}
    }
}
