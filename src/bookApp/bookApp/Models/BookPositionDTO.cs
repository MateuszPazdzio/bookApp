using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class BookPositionDTO
    {
        public string ISBN { get; set; }
        [Display()]
        public string Title { get; set; } // Represents the title of the book
        public string CoverType { get; set; } // Represents the type of the book cover
        [Display(Name = "Na Sprzedaż")]
        public bool IsTransferableToStore { get; set; } // Indicates if the book can be transferred for sale
        [Display(Name = "Cena Sprzedaży")]
        public decimal? SellingPrice { get; set; } // The selling price of the book
        [Display(Name = "Cena wypożyczenia za dzień")]
        public decimal RentalFee { get; set; } // The rental fee per day
        [Display(Name = "Opłata za 1 dzień opóżnienia")]
        public decimal LateFee { get; set; } // The rental fee per day
        [Display(Name = "Data utworzenia")]
        public DateTime CreationDate { get; set; } // The date the record was created
        [Display(Name ="Liczba książek")]
        public int BookPositionCount { get; set; } // Count of book positions for the specific ISBN
    }


}
