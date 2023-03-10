using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Staff
    {
        public int staffId { get; set; }

        public int personId { get; set; }

        public Person? Person { get; set; }

        [NotMapped]
        public IList<WorkedAt>? WorkedAts { get; set; }



    }
}