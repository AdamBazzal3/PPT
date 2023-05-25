namespace PPT.Models
{
    public class Doctor
    { 
        public int id { get; set; }
        public string universityId { get; set; }
        public string rank { get; set; }//what is this for? maybe: contract,manager,main,secondary
        public string officeLocation { get; set; }
        public string email { get; set; }

        public List<Attendance> attendances { get; set; }

    }
}
