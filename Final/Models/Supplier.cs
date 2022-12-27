using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Supplier
    {
        public int? supplierId { get; set; }
        [NotMapped]
        public IList<Supplying>? Supplyings { get; set; }

        public string? name { get; set; }


    }
}