namespace Final.Models
{
    public class Supplying
    {
        public int? supplyingId { get; set; }

        public int? supplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public int? productId { get; set; }

        public Product? Product { get; set; }

        public int amount { get; set; }

        public DateTime? orderedAt { get; set; }

        public DateTime? arrivedAt { get; set; }

        public bool? hasArrived { get; set; }



    }
}