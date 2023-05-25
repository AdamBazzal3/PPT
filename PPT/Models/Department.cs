using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Department
    {
        [Key]
        int id { get; set; }
        string name { get; set; }
        List<Doctor> doctors { get; set; }
        Section section { get; set; }
    }
}
