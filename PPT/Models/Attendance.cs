namespace PPT.Models
{
    public class Attendance
    {
        int id { get; set; }
        DateTime date { get; set; }
        int duration { get; set; } // default 0 , this is only for contract dr
    }
}
