using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PPT.Data;
using PPT.Models;
using PPT.Repositories;
using System.ComponentModel.DataAnnotations;

namespace PPT.Pages
{
    [Authorize(Roles = "Secretary")]
    public class DoctorAttendanceModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IRepository<Attendance> _attendanceRepository;
        private readonly IRepository<Department> _departmentsRepository;
        public SelectList? DoctorsList { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<string>? AreChecked { get; set; } = null;
        [BindProperty(SupportsGet = true)]
        public List<int>? durations { get; set; } = null;
        private User user;
        public static Department department;
        public DoctorAttendanceModel(UserManager<User> userManager, IRepository<Doctor> doctorRepository, IRepository<Attendance> attendanceRepository, IRepository<Department> departmentRepository)
        {
            _userManager = userManager;
            _doctorRepository = (SqlServerRepository<Doctor>)doctorRepository;
            _attendanceRepository = (SqlServerRepository<Attendance>)attendanceRepository;
            _departmentsRepository = (SqlServerRepository<Department>)departmentRepository;
        }
        public static List<Doctor>? Doctors { get; set; }
        //public void OnGet()
        //{
        //}
        public void OnGet()
        {
            user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            department = _departmentsRepository.GetEntityWithCondition((d)=>d.SecretaryID == user.Id);
            Doctors = _doctorRepository.GetEntitiesWithCondition(d => d.DepartmentID == department.ID);
            //var doctors = from m in _doctorRepository.
            //              select m;
            //Doctors = await doctors.ToListAsync();
            this.DoctorsList = new SelectList(Doctors, "ID", "Name");
        }
        //public async Task OnGetSearchAsync()
        //{
        //    var doctors = from m in _context.doctors
        //                 select m;
        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        doctors = doctors.Where(s => s.name.Contains(SearchString));
        //        Doctors = await doctors.ToListAsync();
        //    }
        //}
        public async Task<IActionResult> OnGetDateAttendance(string? id, [DataType(DataType.Date)] List<string>? AreChecked,List<int>? durations)
        {

            if (id != null && id!="0" && AreChecked!=null)
            {
				//user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
				//department = _departmentsRepository.GetEntityWithCondition((d) => d.SecretaryID == user.Id);
				List<Attendance> list = new List<Attendance>();
                List<Attendance> old;
                DateTime temp;
                if (DateTime.TryParse(AreChecked[0], out temp))
                    old = _attendanceRepository.GetAttendanceByDateForDepartment(department.ID, new DateTime(temp.Year,temp.Month,1));
                else
                    return null;
                bool flag = false;
                for(int i = 0; i < AreChecked.Count; i++)
                {
                    DateTime date;
                    if(DateTime.TryParse(AreChecked[i], out date))
                    {
                        flag = false;
                        foreach(var att in old)
                        {
                            if (att.DoctorID == int.Parse(id) && att.Date.CompareTo(date) == 0)
                            {
                                flag = true;
                                break;
                            }
                        }
                        //if attendance dooes not exist,add it, otherwise discard
                        if(!flag)
                        {
                            Attendance attendance = new Attendance();
                            attendance.DoctorID = int.Parse(id);
                            attendance.Date = date;
                            attendance.IsPublished = false;
                            if(durations != null && durations.Count!=0)
                                attendance.Duration = durations[i];
                            list.Add(attendance);
                        }

                    }

                }
                try
                {
                    await _attendanceRepository.InsertAllAsync(list);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return RedirectToPage("/MonthlyReports");

        }

        public JsonResult OnGetIsContractedAsync(int id)
        {
            foreach (var d in Doctors)
                if (d.ID == id && d.IsContracted!=null && (bool)d.IsContracted==true) return new JsonResult("true");
            return new JsonResult("false");
        }


    }
}
