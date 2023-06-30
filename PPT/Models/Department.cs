using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Doctor>? Doctors { get; set; }
        public int? BranchID { get; set; }
        public Branch? Branch { get; set; }
        public string? SecretaryID { get; set; }
        public virtual User? Secretary { get; set; }
        public string? HeadID { get; set; }
        public virtual User? Head { get; set; }
    }
}
