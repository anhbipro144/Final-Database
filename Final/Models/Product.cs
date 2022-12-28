
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Product
    {
        public int productId { get; set; }

        public string? productName { get; set; }
        [NotMapped]
        public IList<Supplying>? Supplyings { get; set; }
        [NotMapped]
        public IList<Storage>? Storages { get; set; }
        [NotMapped]
        public IList<Refund>? Refunds { get; set; }
        [NotMapped]
        public IList<OrderItem>? OrderItems { get; set; }
        [Required]
        public int categoryId { get; set; }
        [Required]
        public decimal? price { get; set; }

    }
}