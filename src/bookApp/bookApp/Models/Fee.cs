namespace bookApp.Models
{
    //only for rental
    public class Fee
    {
        public Guid Id { get; set; }
        public Customer Customer{ get; set; }
        public Rental Rental{ get; set; }
        public string Type{ get; set; }
        
        public decimal Value { get; set; }
    }
}
