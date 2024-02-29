using BooksStore.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;
using BooksStore.Data.Models;

namespace BooksStore.Data.Service
{
    public class AuthorsService
    {
        private BookDbContext _context;
        public AuthorsService(BookDbContext context)
        {
            _context = context;
        }   


        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }


        public AuthorWithBooksVM GetAuthorwithBooks(int AuthorId)
        {
            var _author = _context.Authors.Where(x => x.Id == AuthorId).Select(AuthorBooks => new AuthorWithBooksVM()
            {
                FullName = AuthorBooks.FullName,
                //selecting is redirecting to navigation properities to fill attribues
                BooksTitle = _context.Books_Authors.Select(x => x.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }




    }
}
