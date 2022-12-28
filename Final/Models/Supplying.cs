using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Supplying
    {
        public int supplyingId { get; set; }

        public int supplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public int productId { get; set; }

        public Product? Product { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public DateTime? orderedAt { get; set; }
        [Required]
        public DateTime? arrivedAt { get; set; }
        [Required]
        public bool? hasArrived { get; set; }



    }
}