using BooksStore.Data.ViewModels;
using BooksStore.Data.Models;
using System.Text.RegularExpressions;
using BooksStore.Exceptions;
using BooksStore.Data.Pagination;

namespace BooksStore.Data.Service
{
    public class PublishersController
    {
        private BookDbContext _context;
        public PublishersController(BookDbContext context)
        {
            _context = context;
        }

        // public List<Publisher>  GetAllPublishers() => _context.publishers.tolist();

        public List<PublisherVM>  GetAllPublishers(string?  sortBy,string searchField, int? pageNumber)
        {
            var allpublishers = _context.Publishers.ToList();

            if(!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc":
                        allpublishers = allpublishers.OrderByDescending(x=> x.Name).ToList();
                        break;
                    default
                        : break;
                }
            }

            // for searching
            if(!string.IsNullOrEmpty(searchField))
            {
                allpublishers = allpublishers.Where(x=>x.Name.Contains(searchField)).ToList();
            }

            //for pagination
            int pageSize = 5;
            allpublishers = PaginatedList<PublisherVM>.create(allpublishers.AsQueryable(),pageNumber?? 1,pageSize);

            return allpublishers;
        }
        public PublisherVM AddPublisher(PublishersVM publisher)
        {

            if (stringStartsWithNumber(publisher.PublisherName))
            
                throw new PublisherNameException("Name Starts with Number", publisher.PublisherName);
            
                
            
            var publish = new PublisherVM()

            {
                Name = publisher.PublisherName
            };

            _context.Publishers.Add(publish);
            _context.SaveChanges();
            return publish;


        }

        public List<PublisherVM> GetPublishers() => _context.Publishers.ToList();
        public PublisherVM GetPublisherId(int PublisherId) => _context.Publishers.FirstOrDefault(x => x.Id == PublisherId);

        public PublisherWithBooksAndAuthorVM getPublisherBookAuthorsData(int PublisherId)
        {
            var _publishData = _context.Publishers.Where(x => x.Id == PublisherId).Select(Pba => new PublisherWithBooksAndAuthorVM()
            {
                PublisherName = Pba.Name,
                oneBookAuthors = _context.Books.Select(onBookAuhtors => new BookAuthorsVM()
                {
                    BookName = onBookAuhtors.Title,
                    OneBookAuthors = _context.Books_Authors.Select(x => x.Author.FullName).ToList()
                }).ToList()

            }).ToList().FirstOrDefault();


            return _publishData;
        }


        //    var student = (from s in context.Students where s.studID == "001" select s).FirstOrDefault<Student>();               
        //foreach (Course c in student.Courses.ToList())
        //{
        //    student.Courses.Remove(c);
        //}
        public void deletePublisherjoinbyId(int publisherId)
        {
            var _publisher = _context.Publishers.FirstOrDefault(x => x.Id == publisherId);

            //foreach (var publisher in _publisher )
            //    { _publisher.BooksPublished.Remove(publisher);
            //}

            // var pp = _publisher.BooksPublished.FirstOrDefault();
            
                if (_publisher != null)
                {
                    _context.Publishers.Remove(_publisher);


                    _context.SaveChanges();
                    //}
                }
            
            else {
              throw new Exception($"{publisherId} doesn't Exists!");
            }
            

        

        }

        private bool stringStartsWithNumber(string name) => Regex.IsMatch(name, @"^\d");

        //private bool stringStartsWithNumber(string PublisherName)
        //{
        //    if (Regex.IsMatch(PublisherName, @"^\d")) ;

        //}
    }
}

