using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Product
    {
        public string? productId { get; set; }

        public string? productName { get; set; }
        [NotMapped]
        public IList<Supplying>? Supplyings { get; set; }
        [NotMapped]
        public IList<Inventory>? Inventorys { get; set; }
        [NotMapped]
        public IList<Refund>? Refunds { get; set; }
        [NotMapped]
        public IList<Product_Order>? Product_Orders { get; set; }

        public string? categoryId { get; set; }

        public string? price { get; set; }

    }
}