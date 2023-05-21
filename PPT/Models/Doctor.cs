namespace PPT.Models
{
    public class Doctor
    {
        
        int id { get; set; }
        string universityId { get; set; }
        string rank { get; set; }//what is this for? maybe: contract,manager,main,secondary
        string officeLocation { get; set; }
        string email { get; set; }
    }
}
