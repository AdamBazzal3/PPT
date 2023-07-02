using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPT.Models;
using PPT.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace PPT.Pages
{
    [Authorize(Roles = "Administrator,Secretary")]
    public class MonthlyReportsModel : PageModel
    {
        static List<AttendanceMapper> CSVList = new List<AttendanceMapper>();
        private IWebHostEnvironment Environment;
        private readonly UserManager<User> _userManager;
        private readonly SqlServerRepository<Attendance> _attendanceRepository;
        private static User user;
        private static Department department;
        [BindProperty(SupportsGet = true)]
        public string Date { get; set; }
        public MonthlyReportsModel(UserManager<User> userManager, IWebHostEnvironment _environment, IRepository<Attendance> attendanceRepository)
        {
            this.Environment = _environment;
            _userManager = userManager;
            _attendanceRepository = (SqlServerRepository<Attendance>)attendanceRepository;
        }
        public void OnGet()
        {
            user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            List<string> role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().ToList();
            if(role.ElementAt(0).CompareTo("Secretary")==0)
                department = _attendanceRepository.GetDepartment(user);
            else if (role.ElementAt(0).CompareTo("Administrator")==0)
                department = _attendanceRepository.GetDepartmentByHead(user);
        }
        public JsonResult OnGetReportAsync(string date)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            DateTime Date;
            if (!DateTime.TryParse(date, out Date))
                return null;
            CSVList.Clear();
            //CSVList = new List<AttendanceMapper>();
            List<Attendance> attendances = _attendanceRepository.GetAttendanceByDateForDepartment(department.ID, Date);
            AttendanceMapper mapper;
            foreach (Attendance attendance in attendances)
            {
                mapper = new AttendanceMapper();
                mapper.ID = (int)attendance.DoctorID;
                mapper.Name = attendance.Doctor.Name;
                if (attendance.Doctor.UniversityId != null)
                    mapper.UniID = attendance.Doctor.UniversityId;
                mapper.Date = DateOnly.FromDateTime(attendance.Date);
                if (attendance.Duration != null)
                    mapper.Duration = (int)attendance.Duration;
                if (attendance.IsPublished != null)
                    mapper.Published = (bool)attendance.IsPublished;
                else
                    mapper.Published = false;
                CSVList.Add(mapper);
            }
            return new JsonResult(CSVList);
        }
        public FileResult? OnGetDownload()
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            DateTime date;
            if (!DateTime.TryParse(Date, out date))
                return null;

            string fileName = date.Month + "_" + date.Year + ".csv";
            string path = Path.Combine(this.Environment.WebRootPath, "MReports/") + fileName;
            using (var stream = System.IO.File.OpenWrite(path))
            using (var writer = new StreamWriter(stream,Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(CSVList);
            }
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "text/csv", fileName);
        }
        public class AttendanceMapper
        {
            
            public int ID { get; set; }
            public string UniID { get; set; } = "0";
            public string Name { get; set; }
            public DateOnly Date { get; set; }
            public int Duration { get; set; } = 0;
            [BooleanTrueValues("نعم")]
            [BooleanFalseValues("لا")]
            public bool Published { get; set; }
            //public AttendanceMapper(int id, int uniid,string name,DateOnly date,int duration)
            //{
            //    ID = id; UniID = uniid; Name = name; Date = date; Duration = duration; 
            //}
        }

    }
}
