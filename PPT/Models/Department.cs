namespace PPT.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<Doctor> Doctors;
    }
}
