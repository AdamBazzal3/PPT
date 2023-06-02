using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string? UniversityId { get; set; }
        public string Name { get; set; }
        public bool? IsContracted { get; set; }
        public List<Attendance>? Attendances { get; set; }
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }


    }
}
