using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.ComponentModel;

namespace bookApp.Models
{
    public class BookPosition
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("Book")]
        public Guid BookId {  get; set; }
        public Book Book { get; set; }

        //public int StoreQuantity { get; set; }
        [Required]
        [Range(0,1000)]
        [Display(Name = "Dostępne szt.")]
        public int LibraryQuantity { get; set; }
        //public bool IsAvailableInStore => StoreQuantity > 0;
        public bool IsAvailable => LibraryQuantity > 0;
        //public bool IsAvailableInLibrary => LibraryQuantity > 0;
        [Display(Name = "Na Sprzedaż")]
        public bool IsTransferableToStore { get; set; }

        [DecimalPrecision(10, 2)]
        [Display(Name ="Cena Sprzedaży")]
        public decimal? SellingPrice {  get; set; } //per day
        [DecimalPrecision(10, 2)]
        [Display(Name = "Cena wypożyczenia za dzień")]
        public decimal RentalFee {  get; set; } //per day
        public ICollection<Rental>? Rentals { get; set; }
        public ICollection<Sale>? Sales { get; set; }
    }
}
