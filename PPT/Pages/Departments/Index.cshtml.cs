using System;
using System.Collections.Generic;
using System.Data;
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

namespace PPT.Pages.Departments
{
    [Authorize(Roles = "Manager")]
    public class IndexModel : PageModel
    {
        private readonly PPT.Data.PPTDatacontext _context;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Branch> _branchRepository;
        private readonly IRepository<Department> _departmentRepository;

        public IndexModel(PPT.Data.PPTDatacontext context, UserManager<User> userManager, IRepository<Branch> branchRepository, IRepository<Department> departmentRepository)
        {
            _context = context;
            _userManager = userManager;
            _branchRepository = branchRepository;
            _departmentRepository = departmentRepository;
        }

        public IList<Department> Department { get;set; } = default!;
        private Branch branch;
        private User user;
        public async Task OnGetAsync()
        {
            user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            branch = _branchRepository.GetEntityWithCondition(b=>b.DirectorID.Equals(user.Id));
            if (_context.Departments != null && branch != null)
            {
                Department = _departmentRepository.GetEntitiesWithCondition(d=>d.BranchID == branch.ID, d=>d.Secretary,d=>d.Head);
            }
        }
    }
}
