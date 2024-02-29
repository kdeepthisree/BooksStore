using BooksStore.Data.Models;

namespace BooksStore.Data.ViewModels
{
    public class CustomActionResult
    {
        public Exception Exception { get; set; }
        public PublisherVM publisher { get; set; }
    }
}
