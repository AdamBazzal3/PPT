using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPT.Data;
using PPT.Models;
using PPT.Repositories;
using PPT.Services;

namespace PPT.Pages.Doctors
{
    [Authorize(Roles ="Administrator,Secretary")]
    public class IndexModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;
        private readonly IRepository<Department> _departmentRepository;
        private readonly UserManager<User> _userManager;

        public IndexModel(PPT.Data.PPTDatacontext context,IRepository<Department> departmentRepository, UserManager<User> userManager)
        {
            _departmentRepository = departmentRepository;
            _context = context;
            _userManager = userManager;
        }
        public Department department { get; set; }
        public IList<Doctor> Doctor { get;set; } = default!;
        public User user;

        public async Task OnGetAsync()
        {
            if (_context.Doctors != null)
            {
                user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
                department = _departmentRepository.GetEntityWithCondition(d => d.Head.Id.Equals(user.Id));
                Doctor = await _context.Doctors.Where(d => d.DepartmentID == department.ID)
                .Include(d => d.Department).ToListAsync();
            }
        }
    }
}
