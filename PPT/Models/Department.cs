using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
        public int SectionID { get; set; }
        public Section Section { get; set; }
        public string? SecretaryID { get; set; }
        public virtual User Secretary { get; set; }
    }
}
