using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Attendance
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int? Duration { get; set; } // default 0 , this is only for contract dr
        public bool? IsPublished { get; set; } // default 0 for pending, 1 for published
        public int DoctorID { get; set; }

        public Doctor Doctor { get; set; }
    }
}
