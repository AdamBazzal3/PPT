using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PPT.Data;
using PPT.Models;
using System.ComponentModel.DataAnnotations;

namespace PPT.Pages
{
    public class DoctorAttendanceModel : PageModel
    {
        readonly PPTDatacontext _context;
        public SelectList? DoctorsList { get; set; }
        public DoctorAttendanceModel(PPTDatacontext context)
        {
            _context = context;
        }
        public List<Doctor>? Doctors { get; set; }
        //public void OnGet()
        //{
        //}
        public async Task OnGetAsync()
        {
            var doctors = from m in _context.Doctors
                          select m;
            Doctors = await doctors.ToListAsync();
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
        public void OnGetByDay()
        {
            if(IsChecked != null && AttendanceDate != null)
            {
                DateOnly AttDate = DateOnly.FromDateTime((DateTime)AttendanceDate);

            }
            

        }


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet =true)]
        public string? IsChecked { get; set; }

        [BindProperty(SupportsGet =true)]
        [DataType(DataType.Date)]
        public DateTime? AttendanceDate { get; set; }

    }
}
