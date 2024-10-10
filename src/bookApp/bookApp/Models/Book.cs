using Microsoft.EntityFrameworkCore;

namespace bookApp.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public int PublishYear {  get; set; }

    }
}
