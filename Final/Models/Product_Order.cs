using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Keyless]
    public class Product_Order
    {
        public int? orderId { get; set; }

        public Order? Order { get; set; }

        public int? productId { get; set; }

        public Product? Product { get; set; }

        public int? quantity { get; set; }

        public decimal? total { get; set; }

        public string? countingUnit { get; set; }


    }
}