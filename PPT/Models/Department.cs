using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public List<Doctor>? doctors { get; set; }
        public Section? section { get; set; }
    }
}
