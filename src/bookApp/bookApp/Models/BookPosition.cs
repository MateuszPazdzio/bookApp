using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace bookApp.Models
{
    public class BookPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ISBN { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId {  get; set; }
        public Book Book { get; set; }

        //public int StoreQuantity { get; set; }
        //[Required]
        //[Range(0,1000)]
        [Display(Name = "Dostępne szt.")]
        public int? LibraryQuantity => BookInventories?.Count();
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
        [DecimalPrecision(10, 2)]
        [Display(Name = "Opłata za 1 dzień opóżnienia")]
        public decimal LateFee {  get; set; } //per day

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
        public ICollection<Sale>? Sales { get; set; }
        public ICollection<BookInventory>? BookInventories { get; set; } = new List<BookInventory>();
        
        [Required]
        [ForeignKey("BookCover")]
        public int BookCoverId { get; set; }
        public BookCover BookCover { get; set; }
        [NotMapped]
        public BookInventory BookInventory { get; set; }

    }
}
