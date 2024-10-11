using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("BookPosition")]
        public Guid BookPositionId { get; set; }
        public BookPosition BookPosition { get; set; }
        [ForeignKey("Transaction")]
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        [Precision(10,2)]
        public decimal Value {  get; set; } 

    }
}
