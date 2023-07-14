using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging.Signing;
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
                var Doctors = _doctorRepository.GetEntitiesWithCondition(d => d.Department.ID == department.ID && d.Attendances.Any(a => a.Date.Date.Equals(date.Date)), (doctor)=>doctor.Department, (doctor)=>doctor.Attendances);
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
            try
            {
                date = HttpContext.Session.GetObjectFromJson<DateTime>(SessionKeyDate);
                department = HttpContext.Session.GetObjectFromJson<Department>(SessionKeyDepartment);

                var doctors = _doctorRepository.GetEntitiesWithCondition(d => d.Department.ID == department.ID && !d.Attendances.Any(a => a.Date.Date == date.Date), (doctor) => doctor.Department);

                return new JsonResult(doctors);
            }
            catch(Exception e)
            {
                return new JsonResult(e.ToString());
            }
        }
        public IActionResult OnPostDelete([Required(ErrorMessage = "لا بيانات")][FromBody] int?[] ids)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    date = HttpContext.Session.GetObjectFromJson<DateTime>(SessionKeyDate);
            
                    _attendanceRepository.DeleteRange(a => ids.ToList().Contains(a.DoctorID) && a.Date.Date.Equals(date));

                    return new EmptyResult();
                }
                catch (Exception e)
                {
                    return new EmptyResult();
                }
            }
            else
            {
                return Redirect("/Error");
            }
        }

        public IActionResult OnPostUpdate([Required(ErrorMessage = "لا بيانات")][FromBody] AttendanceModel?[] updates)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    date = HttpContext.Session.GetObjectFromJson<DateTime>(SessionKeyDate);
                    List<Attendance> attendances = new List<Attendance>();
                    foreach (var m in updates)
                    {
                        attendances.Add(new Attendance
                        {
                            ID = m.id,
                            DoctorID = m.doctorId,
                            Date = date,
                            Duration = m.isContracted ? int.Parse(m.duration) : null,
                        });
                    }
                    _attendanceRepository.UpdateRange(attendances);

                    return new EmptyResult();
                }
                catch (Exception e)
                {
                    return new EmptyResult();
                }
            }
            else
            {
                return Redirect("/Error");
            }
        }
        public IActionResult OnPostSave([Required(ErrorMessage = "لا بيانات")][FromBody] AttendanceModel[] models)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    date = HttpContext.Session.GetObjectFromJson<DateTime>(SessionKeyDate);
                    List<Attendance> attendances = new List<Attendance>();
                    foreach(var m in models)
                    {
                        attendances.Add(new Attendance
                        {
                            DoctorID = m.doctorId,
                            Date = date,
                            Duration = m.isContracted? int.Parse(m.duration): null,
                        });
                    }

                    _attendanceRepository.InsertRange(attendances);

                    return new EmptyResult();
                }
                catch (Exception)
                {
                    return new EmptyResult();
                }
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }

    public class AttendanceModel
    {
        public int id { get; set; }
        public int doctorId { get; set; }
        public bool isContracted { get; set; }
        public string duration { get; set; }
    }
}

