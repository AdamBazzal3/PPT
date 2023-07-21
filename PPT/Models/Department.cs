using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Display(Name = "القسم")]
        public string Name { get; set; }
        public virtual List<Doctor>? Doctors { get; set; }
        [Display(Name = "الفرع")]
        public int? BranchID { get; set; }
        [Display(Name = "الفرع")]
        public Branch? Branch { get; set; }
        [Display(Name = "سكرتير")]
        public string? SecretaryID { get; set; }
        [Display(Name = "سكرتير")]
        public virtual User? Secretary { get; set; }
        [Display(Name = "رئيس القسم")]
        public string? HeadID { get; set; }
        [Display(Name = "رئيس القسم")]
        public virtual User? Head { get; set; }
    }
}
