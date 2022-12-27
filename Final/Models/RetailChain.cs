using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class RetailChain
    {
        [Key]
        public int? retailId { get; set; }

        [NotMapped]
        public IList<EmployedAt>? EmployedAts { get; set; }

        [NotMapped]
        public IList<Inventory>? Inventorys { get; set; }

        public string? name { get; set; }

        public string? address { get; set; }


    }
}