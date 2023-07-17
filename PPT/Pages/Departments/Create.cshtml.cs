using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPT.Data;
using PPT.Models;

namespace PPT.Pages.Departments
{
    [Authorize(Roles ="Director")]
    public class CreateModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;

        public CreateModel(PPT.Data.PPTDatacontext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BranchID"] = new SelectList(_context.Branches, "ID", "Name");
        ViewData["HeadID"] = new SelectList(_context.users, "Id", "ConcatenatedName");
        ViewData["SecretaryID"] = new SelectList(_context.users, "Id", "ConcatenatedName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Departments == null || Department == null)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
