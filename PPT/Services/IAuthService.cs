using PPT.Models;
using System.Security.Claims;

namespace PPT.Services
{
    public interface IAuthService
    {
        public Department GetDepartment(User user);
    }
}
