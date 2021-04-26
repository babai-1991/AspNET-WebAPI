using System.Data.Entity;

namespace LibraryServices.Data.Models
{
    class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
