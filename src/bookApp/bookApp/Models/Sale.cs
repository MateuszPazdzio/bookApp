using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("BookPosition")]
        public int BookPositionId { get; set; }
        public BookPosition BookPosition { get; set; }
        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        [Precision(10,2)]
        public decimal Value {  get; set; } 

        public bool IsPaid { get; set; }

    }
}
