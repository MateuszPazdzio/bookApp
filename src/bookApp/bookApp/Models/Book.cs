using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class Book
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string ISBN { get; set; }
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

    }
}
