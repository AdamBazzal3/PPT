using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using PPT.Models;
using PPT.Repositories;
using PPT.Services;
using PPT.Validation;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PPT.Pages
{
    [Authorize(Roles = "Secretary")]
    public class PresenceByDayModel : PageModel
    {
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IRepository<Attendance> _attendanceRepository;
        private readonly IRepository<Department> _departmentRepository;
        //private readonly IAuthService _authService; 
        private readonly UserManager<User> _userManager;

        public const string SessionKeyDepartment = "_Department";
        public const string SessionKeyDate = "_Date";


        public PresenceByDayModel(UserManager<User> userManager, IRepository<Doctor> doctorRepository, IRepository<Attendance> attendanceRepository, IRepository<Department> departmentRepository)
        {
            _doctorRepository = (SqlServerRepository<Doctor>)doctorRepository;
            _attendanceRepository = (SqlServerRepository<Attendance>)attendanceRepository;
            //_authService = (AuthService)authService;
            _userManager = userManager;
            _departmentRepository = (SqlServerRepository<Department>)departmentRepository;
        }

        public DateTime date { get; set; }
        private User user;
        public Department department { get; set; }
        public void OnGet() { }
        public JsonResult OnGetAttendances([Required] [DataType(DataType.Date)] [AttendanceDate] string encodedDate)
        {
            if (ModelState.IsValid)
            {
                string decodedDate = HttpUtility.UrlDecode(encodedDate);

                date = DateTime.Parse(decodedDate);
                HttpContext.Session.SetObjectAsJson(SessionKeyDate, date);

                user = _userManager.GetUserAsync(User).GetAwaiter().GetResult(); ;

                if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyDepartment)))
                {
                    department = _departmentRepository.GetEntityWithCondition(d=>d.Secretary.Id.Equals(user.Id));
                    HttpContext.Session.SetObjectAsJson(SessionKeyDepartment, department);
                }
                else
                {
                    department = HttpContext.Session.GetObjectFromJson<Department>(SessionKeyDepartment);
                }
                //Htession.SetObjectInSession("Department", department);
                //department = _authService.GetEntityWithCondition(user);
                var Doctors = _doctorRepository.GetEntitiesWithCondition<Department>(d => d.Department.ID == department.ID && d.Attendances.Any(a => a.Date.Date == date.Date), (doctor)=>doctor.Department);
                //var serializedData = JsonSerializer.Serialize(Doctors, _jsonOptions);

                return new JsonResult(Doctors);
            }
            else
            {
                // Return the JsonResult
                return new JsonResult("an error occured");
            }
        
        }
        
        public JsonResult OnGetDoctors()
        {
                department = HttpContext.Session.GetObjectFromJson<Department>(SessionKeyDepartment);
            //department = HttpContext.Session.GetCustomObjectFromSession<Department>("Department");
            var doctors = _doctorRepository.GetEntitiesWithCondition(d => d.Department.ID == department.ID, (doctor)=>doctor.Department);

            return new JsonResult(doctors);
        }
        public IActionResult OnPostDelete([Required(ErrorMessage = "لا بيانات")][FromBody] int?[] ids)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    date = HttpContext.Session.GetObjectFromJson<DateTime>(SessionKeyDate);
            
                    _attendanceRepository.DeleteRange(a => ids.ToList().Contains(a.DoctorID) && a.Date.Date.Equals(date));
                    
                    return Page();
                }
                catch (Exception e)
                {
                    return Page();
                }
            }
            else
            {
                return Redirect("/Error");
            }
        }
        public IActionResult OnPostSave([Required(ErrorMessage = "لا بيانات")][FromBody] int?[] ids)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    date = HttpContext.Session.GetObjectFromJson<DateTime>(SessionKeyDate);

                    _attendanceRepository.DeleteRange(a => ids.ToList().Contains(a.DoctorID) && a.Date.Date.Equals(date));

                    return Page();
                }
                catch (Exception e)
                {
                    return Page();
                }
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }

    
}

