using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        public Customer Customer{ get; set; }
        public List<Sale> Sales { get; set; }
        public List<Rental> Rentals{ get; set; }

    }
}
