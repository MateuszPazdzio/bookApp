namespace bookApp.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Customer Customer{ get; set; }
        public List<Sale> Sales { get; set; }
        public List<Rental> Rentals{ get; set; }

    }
}
