using System.Data.Entity;

namespace LibraryServices.Data.Models
{
    class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {
            // drop and re-create the database
            Database.SetInitializer<LibraryContext>(new DropCreateDatabaseIfModelChanges<LibraryContext>());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cost> Costs { get; set; }
    }
}
