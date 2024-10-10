using Microsoft.EntityFrameworkCore;

namespace bookApp.Models
{
    public class BookPosition
    {
        public Book Book { get; set; }
        public int StoreQuantity { get; set; }
        public int LibraryQuantity { get; set; }
        public bool IsAvailableInStore => StoreQuantity > 0;
        public bool IsAvailableInLibrary => LibraryQuantity > 0;
        [Precision(10,2)]
        public decimal Price { get; set; }
    }
}
