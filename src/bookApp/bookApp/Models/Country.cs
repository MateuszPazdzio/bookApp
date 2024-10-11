using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
