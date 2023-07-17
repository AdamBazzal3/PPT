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

namespace PPT.Pages.Departments
{
    [Authorize(Roles = "Director")]
    public class EditModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;

        public EditModel(PPT.Data.PPTDatacontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department =  await _context.Departments.FirstOrDefaultAsync(m => m.ID == id);
            if (department == null)
            {
                return NotFound();
            }
            Department = department;
            ViewData["BranchID"] = new SelectList(_context.Branches, "ID", "Name");
            ViewData["HeadID"] = new SelectList(_context.users, "Id", "ConcatenatedName");
            ViewData["SecretaryID"] = new SelectList(_context.users, "Id", "ConcatenatedName");
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

            _context.Attach(Department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(Department.ID))
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

        private bool DepartmentExists(int id)
        {
          return (_context.Departments?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
