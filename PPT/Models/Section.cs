using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Section
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public List<Department> departments { get; set; }

    }
}
