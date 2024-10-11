using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    //only for rental
    public class RentalFee
    {
        [Key]
        public Guid Id { get; set; }
        //public Customer Customer{ get; set; }
        [ForeignKey("Rental")]
        public Guid RentalId { get; set; }
        public Rental Rental{ get; set; }
        //public string Type{ get; set; }
        [Precision(10, 2)]
        public decimal Value { get; set; } //if Type=Wynajem => RentalFee * (ExpectedReturnDate-RentalDate)
    }
}
