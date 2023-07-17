using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPT.Data;
using PPT.Models;

namespace PPT.Pages.Departments
{
    [Authorize(Roles = "Director")]
    public class IndexModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;

        public IndexModel(PPT.Data.PPTDatacontext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Department = await _context.Departments
                .Include(d => d.Branch)
                .Include(d => d.Head)
                .Include(d => d.Secretary).ToListAsync();
            }
        }
    }
}
