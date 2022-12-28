using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Supplier
    {
        public int supplierId { get; set; }
        [NotMapped]
        public IList<Supplying>? Supplyings { get; set; }
        [Required]
        public string? name { get; set; }


    }
}