using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Data
{
    public class LibraryContext : DbContext
    {
        // Constructor to pass options to the base DbContext class
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        // DbSet property to represent the Books table
        public DbSet<Book> Books { get; set; }
    }
}
