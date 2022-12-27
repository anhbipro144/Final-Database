namespace Final.Models
{
    public class Refund
    {
        public int? refundId { get; set; }

        public int? orderId { get; set; }

        public Order? Order { get; set; }

        public int? productId { get; set; }

        public Product? Product { get; set; }

        public DateTime? createdAt { get; set; }

        public string? reason { get; set; }

    }
}