using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Keyless]
    public class WorkedAt
    {
        public int retailId { get; set; }

        public Retail? Retail { get; set; }

        public int staffId { get; set; }

        public Staff? Staff { get; set; }
        [Required]
        public string? role { get; set; }
        [Required]
        public DateTime? employedSince { get; set; }


    }
}