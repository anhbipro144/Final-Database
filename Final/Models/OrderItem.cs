using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Keyless]
    public class OrderItem
    {
        public int orderId { get; set; }

        public Order? Order { get; set; }

        public int productId { get; set; }

        public Product? Product { get; set; }
        [Required]
        public int? quantity { get; set; }
        [Required]
        public decimal? total { get; set; }
        [Required]
        public string? countingUnit { get; set; }


    }
}