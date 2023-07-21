using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Models
{
    public class Doctor
    {
        [Display(Name = "الرقم")]
        public int ID { get; set; }
        [Display(Name = "الرقم الجامعي")]
        public string? UniversityId { get; set; }
        [Display(Name = "الإسم")]
        public string Name { get; set; }
        [Display(Name = "متعاقد")]
        public bool IsContracted { get; set; } = false;
        [Display(Name = "الحضور")]
        public virtual List<Attendance>? Attendances { get; set; }
        [Display(Name = "القسم")]
        public int? DepartmentID { get; set; }
        [Display(Name = "القسم")]
        public virtual Department? Department { get; set; }
    }
}
