using System.ComponentModel.DataAnnotations;

namespace PPT.Models
{
    public class Faculty
    {
        [Key]
        int id { get; set; }
        string name { get; set; }
        List<Section> sections { get; set; }

    }
}
