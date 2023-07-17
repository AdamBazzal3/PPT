using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPT.Models;
using PPT.Repositories;
using System.Globalization;
using System.Text;

namespace PPT.Pages
{
    [Authorize(Roles = "Manager")]
    public class BranchReportsModel : PageModel
    {
        static List<AttendanceMapper> CSVList = new List<AttendanceMapper>();
        private IWebHostEnvironment Environment;
        private readonly UserManager<User> _userManager;
        private readonly SqlServerRepository<Attendance> _attendanceRepository;
        private static User user;
        private Branch branch;
        public SelectList? DepartmentsList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Date { get; set; }
        public BranchReportsModel(UserManager<User> userManager, IWebHostEnvironment _environment, IRepository<Attendance> attendanceRepository)
        {
            this.Environment = _environment;
            _userManager = userManager;
            _attendanceRepository = (SqlServerRepository<Attendance>)attendanceRepository;
        }
        public void OnGet()
        {
            user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            branch = _attendanceRepository.GetBranch(user);
            DepartmentsList = new SelectList(branch.Departments, "ID", "Name");
        }
        public JsonResult OnGetReportAsync(string date,int id)
        {
            user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            branch = _attendanceRepository.GetBranch(user);
            if (!ModelState.IsValid)
            {
                return null;
            }
            DateTime Date;
            if (!DateTime.TryParse(date, out Date))
                return null;
            if (id == null || id == 0)
                return null;
            CSVList.Clear();
            CSVList = new List<AttendanceMapper>();
            List<Attendance> attendances = _attendanceRepository.GetAttendanceByDateForDepartment(id, Date);
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
        public FileResult? OnGetDownload(int depid)
        {
            user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            branch = _attendanceRepository.GetBranch(user);
            if (!ModelState.IsValid)
            {
                return null;
            }
            DateTime date;
            if (!DateTime.TryParse(Date, out date))
                return null;
            string depname= "";
            foreach(var dep in branch.Departments)
                if(dep.ID == depid)
                {
                    depname = dep.Name;
                    break;
                }
            string fileName = depname+"_"+ date.Month + "_" + date.Year + ".csv";
            string path = Path.Combine(this.Environment.WebRootPath, "MReports/") + fileName;
            using (var stream = System.IO.File.OpenWrite(path))
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
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
