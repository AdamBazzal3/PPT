using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PPT.Pages
{
    using global::PPT.Models;
    using global::PPT.Repositories;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using PPT.Models;
    using System.Collections.Generic;
    using System.Linq;
        public class PublishModel : PageModel
        {
            private readonly UserManager<User> _userManager;
            private readonly IRepository<Doctor> _doctorRepository;
            private readonly IRepository<Attendance> _attendanceRepository;
            private readonly IRepository<Department> _departmentsRepository;

            public PublishModel(UserManager<User> userManager, IRepository<Doctor> doctorRepository, IRepository<Attendance> attendanceRepository, IRepository<Department> departmentRepository)
                {
                    _userManager = userManager;
                    _doctorRepository = (SqlServerRepository<Doctor>)doctorRepository;
                    _attendanceRepository = (SqlServerRepository<Attendance>)attendanceRepository;
                    _departmentsRepository = (SqlServerRepository<Department>)departmentRepository;
            }

            [BindProperty(SupportsGet = true)]
            public DateTime SelectedMonth { get; set; }

            [BindProperty]
            public List<Doctor>? Doctors { get; set; } = new List<Doctor>();

            private User user;
            private Department department;

            public void OnGet()
            {


                SelectedMonth = DateTime.Today;

                user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
                department = _departmentsRepository.GetEntityWithCondition((d) => d.SecretaryID == user.Id);
                Doctors = _doctorRepository.GetEntitiesWithCondition(d => d.Department.ID == department.ID && d.Attendances.Any(a => a.Date.Year == SelectedMonth.Year && a.Date.Month == SelectedMonth.Month && a.IsPublished != true));
                foreach (var d in Doctors)
                {
                    d.Attendances = _attendanceRepository.GetEntitiesWithCondition(a => a.DoctorID == d.ID && a.Date.Year == SelectedMonth.Year && a.Date.Month == SelectedMonth.Month && a.IsPublished != true);
                }
            }
                public IActionResult OnPostShowAttendance()
            {
                if (ModelState.IsValid)
                {
                    user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
                    department = _doctorRepository.GetDepartment(user);
                    Doctors = _doctorRepository.GetEntitiesWithCondition(d => d.Department.ID == department.ID && d.Attendances.Any(a => a.Date.Year == SelectedMonth.Year && a.Date.Month==SelectedMonth.Month && a.IsPublished!=true));
                    foreach(var d in Doctors)
                    {
                        d.Attendances = _attendanceRepository.GetEntitiesWithCondition(a => a.DoctorID==d.ID && a.Date.Year == SelectedMonth.Year && a.Date.Month == SelectedMonth.Month && a.IsPublished != true);
                    }
                }

                return Page();
            }

            public IActionResult OnPostPublishAttendances(int[] attendanceIds)
            {
                if (attendanceIds != null && attendanceIds.Length > 0)
                {
                    foreach (var attendanceId in attendanceIds)
                    {
                        Attendance attendance = _attendanceRepository.GetByIntAsync(attendanceId).GetAwaiter().GetResult();
                        if (attendance != null)
                        {
                            attendance.IsPublished = true;
                            _attendanceRepository.Update(attendance);
                        }
                    }
                }

                return RedirectToPage();
            }
        }
    }


