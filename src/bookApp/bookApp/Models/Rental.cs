using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Foreign key to Customer
        //[ForeignKey("Customer")]
        //public Guid CustomerId { get; set; }
        //public Customer Customer { get; set; }

        // Foreign key to Transaction
        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        // Foreign key to BookPosition
        //[ForeignKey("BookPosition")]
        //public int BookPositionId { get; set; }
        //public BookPosition BookPosition { get; set; }
        [ForeignKey("BookInventory")]
        public int BookInventoryId { get; set; }
        public BookInventory BookInventory { get; set; }

        public DateTime RentalDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        //[Precision(10, 2)]
        //public decimal Value { get; set; }

        // Collection of related LateFee entities
        public LateFee? LateFee { get; set; }
        public RentalFee RentalFee{ get; set; }//zakoment
        
    }
}
