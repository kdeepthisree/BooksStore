using BooksStore.Data.Models;

namespace BooksStore.Data.Service
{
    public class LogsService
    {
        private BookDbContext _dbcontext;

        public LogsService(BookDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        //public List<Log> GetAllLogsFromDb() => _dbcontext.Logs.ToList();

        public List<Log> GetAllLogsFromDb()
        {
            var alllogs= _dbcontext.Logs.ToList();
            return alllogs;
        }
    }
}
