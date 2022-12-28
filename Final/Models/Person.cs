using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Person
    {
        public int personId { get; set; }

        [NotMapped]
        public IList<Order>? Order { get; set; }

        [Required]
        public string? firstName { get; set; }
        [Required]
        public string? lastName { get; set; }
        [Required]
        public DateTime? dateOfBirth { get; set; }
        [Required]
        public string? gender { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? phone { get; set; }
        [Required]
        public string? address { get; set; }
        [Required]
        public string? status { get; set; }
    }
}