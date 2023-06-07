using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Branch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? FacultyID { get; set; }
        public Faculty? Faculty { get; set; }
        public virtual List<Department>? Departments { get; set; }

    }
}
