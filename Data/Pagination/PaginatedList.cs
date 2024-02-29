namespace BooksStore.Data.Pagination
{
    public class PaginatedList<T> : List<T>
    {

        public int page_index { get; private set; }

        public int TotalNoOfPages { get; private set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            page_index = pageIndex;
            TotalNoOfPages = (int)Math.Ceiling(count / (double) pageSize);

            this.AddRange(items);
        }

        //prev arrows and next arrows---in pagination
        public bool  HasPrevPage
        {
            get { return page_index >1;}
        }

        //prev arrow
        public bool HasNextPage
        {
            get
            {
                return page_index < TotalNoOfPages;
            }
        }

        public static PaginatedList<T> create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();

            var items = source.Skip((pageIndex -1)*pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items , count, pageIndex, pageSize);
        }
    }
}
