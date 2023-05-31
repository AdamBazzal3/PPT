using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string? UniversityId { get; set; }
        public string Name { get; set; }
        public bool Rank { get; set; }//what is this for? maybe: contract,manager,main,secondary
        public string? OfficeLocation { get; set; }
        public string? Email { get; set; }
        public List<Attendance> Attendances { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        Department department { get; set; }

    }
}
