using BooksStore.Data.ViewModels;
using BooksStore.Data.Models;

namespace BooksStore.Data.Service
{
    public class BookService
    {
        private readonly BookDbContext _dbContext;
        //ioc container as parameter
        public BookService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddBookWithAuthor(BooksVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,

                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,


                Genere = book.Genere,
                //Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,

                PublisherId = book.PublisherId
            };

            _dbContext.Books.Add(_book);
            _dbContext.SaveChanges();

            foreach(var i in book.AuthorIds)
            {
                var _book_Author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = i
                }; 
                
                _dbContext.Books_Authors.Add(_book_Author);
                _dbContext.SaveChanges();

            }
          
        }


        public List<Book> GetBooks() => _dbContext.Books.ToList();

        //public Book GetbookById(int bookId) => _dbContext.Books.FirstOrDefault(x => x.Id == bookId);

        public BookswithAuthorVM GetbookById(int bookId)
        {
            var _bookWithAuthors = _dbContext.Books.Where(x => x.Id == bookId).Select(BooksAuthor => new BookswithAuthorVM()
            {
                Title = BooksAuthor.Title,
                Description = BooksAuthor.Description,
                IsRead = BooksAuthor.IsRead,
                DateRead = BooksAuthor.IsRead ? BooksAuthor.DateRead.Value : null,
                Rate = BooksAuthor.IsRead ? BooksAuthor.Rate.Value : null,
                Genere = BooksAuthor.Genere,
                CoverUrl = BooksAuthor.CoverUrl,
                PublisherName = BooksAuthor.Publisher.Name,
                AuthorNames = BooksAuthor.Books_Authors.Select(x => x.Author.FullName).ToList()
            }).FirstOrDefault();


            return _bookWithAuthors;
        }
        


        public Book updateBookById(int  bookId, BooksVM book)
        {
            var _bookid= _dbContext.Books.FirstOrDefault(x=>x.Id==bookId);
            if(_bookid != null)
            {
                _bookid.Title = book.Title;
                _bookid.Description = book.Description;
                _bookid.IsRead = book.IsRead;
                _bookid.DateRead   = book.IsRead? book.DateRead.Value : null; ;
                _bookid.Rate = book.IsRead ? book.Rate.Value:null;
                _bookid.Genere = book.Genere;
                //_bookid.Author = book.Author;
                _bookid.CoverUrl = book.CoverUrl;
            }
            _dbContext.SaveChanges();
            return _bookid;

        }


        public void deleteBook(int bookId)
        {
            var _book = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);
                if(_book!=null)
            {
                _dbContext.Books.Remove(_book);
                _dbContext.SaveChanges();
            };
        }
    }
}
