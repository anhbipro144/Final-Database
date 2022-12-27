using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    [Keyless]
    public class EmployedAt
    {
        public int? retailId { get; set; }

        public RetailChain? RetailChain { get; set; }

        public int? staffId { get; set; }

        public Staff? Staff { get; set; }

        public string? role { get; set; }

        public DateTime? employedSince { get; set; }


    }
}