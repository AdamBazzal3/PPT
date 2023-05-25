using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Attendance
    {
        [Key]
        int id { get; set; }
        DateTime date { get; set; }
        int duration { get; set; } // default 0 , this is only for contract dr
        bool isPublished { get; set; } // default 0 for pending, 1 for published
        Doctor doctor { get; set; }
    }
}
