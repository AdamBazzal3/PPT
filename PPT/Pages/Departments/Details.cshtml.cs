﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;

        public DetailsModel(PPT.Data.PPTDatacontext context)
        {
            _context = context;
        }

      public Department Department { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FirstOrDefaultAsync(m => m.ID == id);
            if (department == null)
            {
                return NotFound();
            }
            else 
            {
                Department = department;
            }
            return Page();
        }
    }
}
