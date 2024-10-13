using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class Condition
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Stan książki")]
        public string Name {  get; set; }
    }
}
