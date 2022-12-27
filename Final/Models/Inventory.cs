namespace Final.Models
{
    public class Inventory
    {
        public int? inventoryId { get; set; }

        public int? productId { get; set; }

        public Product? Product { get; set; }

        public int? retailId { get; set; }

        public RetailChain? RetailChain { get; set; }

        public int? quantity { get; set; }
        public DateTime? lastUpdated { get; set; }




    }
}