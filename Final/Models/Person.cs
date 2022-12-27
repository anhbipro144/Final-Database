using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Person
    {
        public int? personId { get; set; }

        [NotMapped]
        public IList<Order>? Order { get; set; }

        public string? firstName { get; set; }

        public string? lastName { get; set; }

        public DateTime? dateOfBirth { get; set; }

        public string? gender { get; set; }

        public string? email { get; set; }

        public string? phone { get; set; }

        public string? address { get; set; }

        public string? status { get; set; }
    }
}