using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPT.Models;
using PPT.Repositories;
using System.Globalization;
using System.Text;

namespace PPT.Pages
{
    [Authorize(Roles = "Administrator")]
    public class DepartmentReportModel : PageModel
    {
        private IWebHostEnvironment Environment;
        private readonly UserManager<User> _userManager;
        private readonly SqlServerRepository<Attendance> _attendanceRepository;
        private static User user;
        private static Department department;

        public DepartmentReportModel(UserManager<User> userManager, IWebHostEnvironment _environment, IRepository<Attendance> attendanceRepository)
        {
            this.Environment = _environment;
            _userManager = userManager;
            _attendanceRepository = (SqlServerRepository<Attendance>)attendanceRepository;
        }
        public void OnGet()
		{

		}
        public FileResult? OnGetDownloadFull(string monthF)
        {
            if (!ModelState.IsValid || monthF=="")
                return null;
            user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            department = _attendanceRepository.GetDepartmentByHead(user);
            DateTime date;
            if (!DateTime.TryParse(monthF, out date))
                return null;
            List<AttendanceMapper> CSVList = _attendanceRepository.GetAttendanceByDateForDepartmentUndetailed(department.ID, date, false, null);

            string fileName = department.Name +"_FinalFullTime_"+ "_" + date.Month + "_" + date.Year + ".csv";
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
        public FileResult? OnGetDownloadPart(string monthP)
        {
            if (!ModelState.IsValid || monthP=="")
                return null;
            user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            department = _attendanceRepository.GetDepartmentByHead(user);
            DateTime date;
            if (!DateTime.TryParse(monthP, out date))
                return null;
            List<AttendanceMapper> CSVList = _attendanceRepository.GetAttendanceByDateForDepartmentUndetailed(department.ID, date, true, true);

            string fileName = department.Name + "_FinalPartTime_" + "_" + date.Month + "_" + date.Year + ".csv";
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
            return null;
        }
        public class AttendanceMapper
        {

            public int ID { get; set; }
            public string UniID { get; set; } = "0";
            public string Name { get; set; }
            public int TotalDays { get; set; }
            public int TotalDuration { get; set; } = 0;
        }
    }
}
