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
        [BindProperty(SupportsGet = true)]
        public List<string>? AreChecked { get; set; } = null;
        [BindProperty(SupportsGet = true)]
        public List<int>? durations { get; set; } = null;
        public DoctorAttendanceModel(PPTDatacontext context)
        {
            _context = context;
        }
        public static List<Doctor>? Doctors { get; set; }
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
        public IActionResult OnGetDateAttendance(List<string>? AreChecked,List<int>? durations)
        {
            return RedirectToPage("/Index");

        }

        public JsonResult OnGetIsContractedAsync(int id)
        {
            foreach (var d in Doctors)
                if (d.ID == id && d.IsContracted!=null && (bool)d.IsContracted==true) return new JsonResult("true");
            return new JsonResult("false");
        }


    }
}
