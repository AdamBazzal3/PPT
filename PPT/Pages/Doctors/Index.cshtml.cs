using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPT.Data;
using PPT.Models;

namespace PPT.Pages.Doctors
{
    [Authorize(Roles ="Administrator")]
    public class IndexModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;

        public IndexModel(PPT.Data.PPTDatacontext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Doctors != null)
            {
                Doctor = await _context.Doctors
                .Include(d => d.Department).ToListAsync();
            }
        }
    }
}
