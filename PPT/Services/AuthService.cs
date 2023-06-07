using Microsoft.AspNetCore.Identity;
using PPT.Models;
using PPT.Repositories;
using System.Security.Claims;

namespace PPT.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<Department> _departmentRepository;
        public AuthService(IRepository<Department> repository)
        {
            _departmentRepository = (SqlServerRepository<Department>)repository;
        }

        public Department GetDepartment(User user)
        {
            return _departmentRepository.GetDepartment(user);
        }

    }
}
