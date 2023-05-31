using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Attendance
    {
        [Key]
        public int id { get; set; }
        public DateOnly date { get; set; }
        public int? duration { get; set; } // default 0 , this is only for contract dr
        public bool? isPublished { get; set; } // default 0 for pending, 1 for published
        public Doctor doctor { get; set; }
    }
}
