using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Retail
    {
        [Key]
        public int retailId { get; set; }

        [NotMapped]
        public IList<WorkedAt>? WorkedAt { get; set; }

        [NotMapped]
        public IList<Storage>? Storage { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? address { get; set; }


    }
}