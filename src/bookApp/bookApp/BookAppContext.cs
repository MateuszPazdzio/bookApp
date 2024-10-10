using bookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookApp
{
    public class BookAppContext : DbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Country> Countries{ get; set; }
        DbSet<Author> Authors{ get; set; }
        DbSet<Category> Categories{ get; set; }
        DbSet<Customer> Customers{ get; set; }
        DbSet<BookPosition> BookPositions{ get; set; }
        DbSet<Fee> Fees{ get; set; }
        DbSet<Rental> Rentals{ get; set; }
        DbSet<Sale> Sales{ get; set; }
        DbSet<Transaction> Transactions{ get; set; }
        DbSet<RaportIncome> RaportsIncome { get; set; }

        public BookAppContext(DbContextOptions<BookAppContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .OwnsOne<Address>(c => c.Address);
        }
    }
}
