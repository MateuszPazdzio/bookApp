using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookApp.Models
{
    public class BookInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]
        [Display(Name = "Nr. Inwentarza")]
        public string? Inventory_Nr { get; set; }
        //[Required]
        //public string ISBN { get; set; }
        [Required]
        [ForeignKey("ConditionId")]
        public int ConditionId { get; set; }
        [Required]
        public Condition Condition { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; }

        //[Required]
        //[ForeignKey("Book")]
        //public Guid BookId { get; set; }
        //public Book Book { get; set; }

    }
}
