using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;

namespace PPT.Models
{
    public class User: IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ConcatenatedName => $"{FirstName} {LastName}";
    }
}
