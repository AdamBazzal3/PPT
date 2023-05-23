using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPT.Models
{
    public class Doctor
    {
        [Key]
        int id { get; set; }
        string universityId { get; set; }
        string rank { get; set; }//what is this for? maybe: contract,manager,main,secondary
        string officeLocation { get; set; }
        string email { get; set; }
        List<Attendance> attendances { get; set; }
        [ForeignKey("department")]
        Department department { get; set; }

    }
}
