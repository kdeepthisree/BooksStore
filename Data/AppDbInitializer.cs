using BooksStore.Data.Models;

namespace BooksStore.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            //appbuilder-->appservice--->servicescope(dbcontext)
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookDbContext>();

               if(!context.Books.Any()) {
                    //entity state--added,modified,updated,deleted,unchanged
                    context.Books.AddRange(
                        new Book()
                        {
                            Title = "First Book",
                            Description = "First Book Description",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-10),
                            Rate = 4,
                            Genere = "BioGraphy",
                            //Author = "First Author",
                            CoverUrl = "https...",
                            DateAdded = DateTime.Now
                        },
                    new Book()
                    {
                        Title = "Second Book",
                        Description = "Second Book Description",
                        IsRead= false,
                        Genere="AUtoBioGraphy",
                        //Author= "Author",
                        CoverUrl="http:...",
                        DateAdded= DateTime.Now

                    }

                    );

                }
                context.SaveChanges();
            }
        }
    }
}
