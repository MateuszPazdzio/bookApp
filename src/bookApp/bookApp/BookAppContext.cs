using bookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookApp
{
    public class BookAppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<BookPosition> BookPositions{ get; set; }
        public DbSet<RentalFee> RentalFees{ get; set; }
        public DbSet<LateFee> LateFees{ get; set; }
        public DbSet<Rental> Rentals{ get; set; }
        public DbSet<Sale> Sales{ get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
        public DbSet<RaportIncome> RaportsIncome { get; set; }
        public DbSet<Condition> Conditions{ get; set; }
        public DbSet<BookCondition> BookCondition { get; set; }


        public BookAppContext(DbContextOptions<BookAppContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Rental>()
                .HasOne(r => r.LateFee)
                .WithOne(c => c.Rental)
                .OnDelete(DeleteBehavior.Cascade); // Deleting Customer deletes associated Rentals

            modelBuilder.Entity<Rental>()
               .HasOne(r => r.RentalFee)
               .WithOne(c => c.Rental)
               .OnDelete(DeleteBehavior.Cascade); // Deleting Customer deletes associated Rentals

            modelBuilder.Entity<Transaction>()
               .HasMany(r => r.Rentals)
               .WithOne(bp => bp.Transaction)
               .HasForeignKey(t => t.TransactionId)
               .OnDelete(DeleteBehavior.Cascade); // Deleting a BookPosition should not delete associated rentals

            modelBuilder.Entity<Transaction>()
              .HasMany(r => r.Sales)
              .WithOne(bp => bp.Transaction)
              .HasForeignKey(t => t.TransactionId)
              .OnDelete(DeleteBehavior.Cascade); // Deleting a BookPosition should not delete associated rentals

            modelBuilder.Entity<Customer>()
                .HasMany(lf => lf.Transactions)
                .WithOne(r => r.Customer)
                .HasForeignKey(lf => lf.CustomerId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting Rental deletes associated LateFees
            //modelBuilder.Entity<LateFee>()
            //    .HasOne(lf => lf.Customer)
            //    .WithMany()
            //    .HasForeignKey(lf => lf.CustomerId)
            //    .OnDelete(DeleteBehavior.Restrict); // Restrict behavior on LateFee deletion

        }
    }
}
