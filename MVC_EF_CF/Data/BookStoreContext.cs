using Microsoft.EntityFrameworkCore;
using MVC_EF_CF.Models;

namespace MVC_EF_CF.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book {  get; set; }
    }
}
