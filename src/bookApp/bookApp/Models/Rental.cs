namespace bookApp.Models
{
    public class Rental
    {
        public Guid Id { get; set; }
        //public Customer Customer { get; set; }
        public List<BookPosition> BookPositions { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        //public decimal Value { get; set; }
    }
}
