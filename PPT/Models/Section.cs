using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Section
    {
        [Key]
        int id { get; set; }
        string name { get; set; }
        
        List<Department> departments { get; set; }

    }
}
