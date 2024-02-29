using BooksStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Data
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<BookDbContext> options) : base(options)
        {
        }
        public BookDbContext() 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=BookStoreLib_99;Trusted_Connection=True;");
           // optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=CRUDLogs;Trusted_Connection=True;");
            //.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=BookStoreLib_99;Trusted_Connection=True;");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ////{
        ////    base.OnConfiguring(optionsBuilder);
        ////    optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=BookStoreLib_99;Trusted_Connection=True;");
        //    //.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=BookStoreLib_99;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //Fluent Api-many to many relations
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Book)
                                               .WithMany(ba => ba.Books_Authors)
                                               .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>().HasOne(a => a.Author)
                                              .WithMany(ab => ab.Books_Authors)
                                              .HasForeignKey(ai => ai.AuthorId);
            modelBuilder.Entity<Log>().HasKey(n=> n.Id);

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<PublisherVM> Publishers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book_Author> Books_Authors { get; set; }

        public DbSet<Log> Logs { get; set; }

    }
}
