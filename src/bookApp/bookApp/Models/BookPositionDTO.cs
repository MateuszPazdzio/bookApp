namespace bookApp.Models
{
    public class BookPositionDTO
    {
        public string ISBN { get; set; }
        public string Title { get; set; } // Represents the title of the book
        public string CoverType { get; set; } // Represents the type of the book cover
        public bool IsTransferableToStore { get; set; } // Indicates if the book can be transferred for sale
        public decimal? SellingPrice { get; set; } // The selling price of the book
        public decimal RentalFee { get; set; } // The rental fee per day
        public decimal LateFee { get; set; } // The rental fee per day
        public DateTime CreationDate { get; set; } // The date the record was created
        public int BookPositionCount { get; set; } // Count of book positions for the specific ISBN
    }


}
