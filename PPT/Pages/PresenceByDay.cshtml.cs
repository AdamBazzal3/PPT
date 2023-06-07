using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPT.Models;
using PPT.Repositories;
using PPT.Services;
using PPT.Validation;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PPT.Pages
{
    [Authorize(Roles = "Secretary")]
    public class PresenceByDayModel : PageModel
    {

        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IRepository<Attendance> _attendanceRepository;
        //private readonly IAuthService _authService; 
        private readonly UserManager<User> _userManager;
        public PresenceByDayModel(UserManager<User> userManager, IRepository<Doctor> doctorRepository, IRepository<Attendance> attendanceRepository)
        {
            _doctorRepository = (SqlServerRepository<Doctor>)doctorRepository;
            _attendanceRepository = (SqlServerRepository<Attendance>)attendanceRepository;
            //_authService = (AuthService)authService;
            _userManager = userManager;
        }

        public DateTime date { get; set; }
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        private User user;
        private Department department;

        public IActionResult OnGet([Required] [DataType(DataType.Date)] [AttendanceDate] string encodedDate)
        {
            if (ModelState.IsValid)
            {
                string decodedDate = HttpUtility.UrlDecode(encodedDate);

                date = DateTime.Parse(decodedDate);
                                user = _userManager.GetUserAsync(User).GetAwaiter().GetResult(); ;
                department = _doctorRepository.GetDepartment(user);
                //department = _authService.GetDepartment(user);

                Doctors = _doctorRepository.GetEntitiesWithCondition(d => d.Department.ID == department.ID && d.Attendances.Any(a => a.Date == date));
                
                return Page();
            }
            else
            {
                return Redirect("/Error");
            }
        }
        
        public JsonResult OnGetDoctors()
        {
            var doctors = _doctorRepository.GetEntitiesWithCondition(d => d.Department.ID == department.ID);

            return new JsonResult(doctors);
        }
        public IActionResult OnPostDelete([Required] int DoctorId, [Required][AttendanceDate] string date)
        {

            if (ModelState.IsValid)
            {
                string decodedDate = HttpUtility.UrlDecode(date);

                _attendanceRepository.DeleteEntitiesWithCondition((attendance) => attendance.Date == DateTime.Parse(decodedDate) && attendance.DoctorID == DoctorId);
                /*date = DateTime.Parse(decodedDate);
                User user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
                Department department = _doctorRepository.GetDepartment(user);
                Doctors = _doctorRepository.GetEntitiesWithCondition(d => d.Department.ID == department.ID && d.Attendances.Any(a => a.Date == date));
                */
                return Page();
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }
}
