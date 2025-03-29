using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Context
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
