using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class LateFee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[ForeignKey("Customer")]
        //public Guid CustomerId { get; set; } // Add Foreign Key Property
        //public Customer Customer { get; set; }

        [ForeignKey("Rental")]
        public int RentalId { get; set; } // Add Foreign Key Property
        public Rental Rental { get; set; }
        [Precision(10, 2)]
        public decimal Value { get; set; } //if (ExpectedReturnDate-GetDate())>0 => (ExpectedReturnDate-GetDate())*FeeLateValue
        public bool IsPaid { get; set; }
    }
}
