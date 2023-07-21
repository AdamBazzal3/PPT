using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPT.Data;
using PPT.Models;

namespace PPT.Pages.Doctors
{
    [Authorize(Roles = "Administrator")]
    public class CreateModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;

        public CreateModel(PPT.Data.PPTDatacontext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Doctors == null || Doctor == null)
            {
                return Page();
            }

            _context.Doctors.Add(Doctor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
