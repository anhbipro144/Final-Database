namespace Final.Models
{
    public class Customer
    {
        public int? customerId { get; set; }

        public int? personId { get; set; }

        public Person? Person { get; set; }
    }
}