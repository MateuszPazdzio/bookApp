using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class BookPosition
    {
        [Key]
        public Guid Id { get; set; }
        public Book Book { get; set; }
        //public int StoreQuantity { get; set; }
        public int LibraryQuantity { get; set; }
        //public bool IsAvailableInStore => StoreQuantity > 0;
        public bool IsAvailable {  get; set; }
        //public bool IsAvailableInLibrary => LibraryQuantity > 0;
        public bool IsTransferableToStore { get; set; }

        [Precision(10,2)]
        public decimal? SellingPrice {  get; set; } //per day
        [Precision(10, 2)]
        public decimal RentalFee {  get; set; } //per day

        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
