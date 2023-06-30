using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Faculty
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Branch>? Branches { get; set; }
        public string? DeanID { get; set; }
        public virtual User? Dean { get; set; }
    }
}
