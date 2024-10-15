using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]
        //public string ISBN { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]

        public Author Author { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public int PublishYear {  get; set; }
        [Display(Name = "URL Okładki")]
        public string CoverImageUrl { get; set; }
        [Display(Name = "Opis")]
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
    }
}
