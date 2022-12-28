using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Storage
    {
        public int storageId { get; set; }

        public int productId { get; set; }

        public Product? Product { get; set; }
        [Required]
        public int retailId { get; set; }
        [NotMapped]
        public Retail? Retail { get; set; }

        public int? available { get; set; }
        public DateTime? lastUpdated { get; set; }




    }
}