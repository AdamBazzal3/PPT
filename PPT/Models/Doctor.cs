using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Models
{
    public class Doctor
    {
        [Key]
        public int id { get; set; }
        public string? universityId { get; set; }
        public string name { get; set; }
        public bool IsContracted { get; set; }//what is this for? maybe: contract,main
        public List<Attendance>? attendances { get; set; }
        public Department? department { get; set; }

    }
}
