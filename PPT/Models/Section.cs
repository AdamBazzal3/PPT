using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Section
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public List<Department>? Departments { get; set; }

    }
}
