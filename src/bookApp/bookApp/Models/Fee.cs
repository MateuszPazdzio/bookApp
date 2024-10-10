namespace bookApp.Models
{
    public class Fee
    {
        public Guid Id { get; set; }
        public Customer Customer{ get; set; }
        public string Type{ get; set; }
        
        public decimal Value { get; set; }
    }
}
