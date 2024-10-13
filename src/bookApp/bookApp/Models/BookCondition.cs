using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookApp.Models
{
    public class BookCondition
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [ForeignKey("ConditionId")]
        public Guid ConditionId { get; set; }
        [Required]
        public Condition Condition { get; set; }
        [Required]
        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

    }
}
