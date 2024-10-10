using bookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookApp
{
    public class BookAppContext : DbContext
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .OwnsOne<Address>(c => c.Address);
        }
    }
}
