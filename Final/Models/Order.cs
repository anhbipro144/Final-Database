using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Order
    {
        public int? orderId { get; set; }

        public int? personId { get; set; }

        public Person? Person { get; set; }
        [NotMapped]
        public IList<Product_Order>? Product_Order { get; set; }
        [NotMapped]
        public IList<Refund>? Refund { get; set; }

        public DateTime? createdAt { get; set; }

        public decimal? vat { get; set; }

        public decimal? subtotal { get; set; }

        public decimal? total { get; set; }

    }
}