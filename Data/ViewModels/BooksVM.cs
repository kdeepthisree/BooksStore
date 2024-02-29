namespace BooksStore.Data.ViewModels
{
    public class BooksVM
    {
        

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public string Genere { get; set; }
        //public string Author { get; set; }

        public string? CoverUrl { get; set; }

        public int PublisherId { get; set; }

        public List<int> AuthorIds { get; set;}
    }



    public class BookswithAuthorVM
    {


        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public string Genere { get; set; }
        //public string Author { get; set; }

        public string? CoverUrl { get; set; }

        public string PublisherName { get; set; }

        public List<String> AuthorNames { get; set; }
    }
}
