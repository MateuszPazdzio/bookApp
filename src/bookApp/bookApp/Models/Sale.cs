using Microsoft.EntityFrameworkCore;

namespace bookApp.Models
{
    public class Sale
    {
        public Guid Id { get; set; }
        public List<BookPosition> BookPositions { get; set; }
        [Precision(10,2)]
        public decimal Value {  get; set; } 

    }
}
