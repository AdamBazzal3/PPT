using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PPT.Data;
using PPT.Models;

namespace PPT.Pages.Doctors
{
    [Authorize(Roles = "Administrator")]
    public class EditModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;

        public EditModel(PPT.Data.PPTDatacontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor =  await _context.Doctors.FirstOrDefaultAsync(m => m.ID == id);
            if (doctor == null)
            {
                return NotFound();
            }
            Doctor = doctor;
           ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(Doctor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DoctorExists(int id)
        {
          return (_context.Doctors?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
