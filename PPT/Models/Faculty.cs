using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Faculty
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public List<Section> sections { get; set; }

    }
}
