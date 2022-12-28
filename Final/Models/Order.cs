using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Order
    {
        public int orderId { get; set; }

        public int personId { get; set; }

        public Person? Person { get; set; }
        [NotMapped]
        public IList<OrderItem>? OrderItems { get; set; }
        [NotMapped]
        public IList<Refund>? Refund { get; set; }
        [Required]
        public DateTime? createdAt { get; set; }
        [Required]
        public decimal? vat { get; set; }
        [Required]
        public decimal? subtotal { get; set; }
        [Required]
        public decimal? total { get; set; }

    }
}