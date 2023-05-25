namespace PPT.Models
{
    public class Attendance
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int duration { get; set; } // default 0 , this is only for contract dr
        
        public Doctor Doctor { get; set; }
    }
}
