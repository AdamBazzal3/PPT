using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPT.Models;
using PPT.Repositories;
using System.Data;

namespace PPT.Pages
{
    [Authorize(Roles = "Secretary")]
    public class PresenceByDayModel : PageModel
    {

        private readonly IRepository<Doctor> _repository;
        public PresenceByDayModel(IRepository<Doctor> repository) {
            _repository = (SqlServerRepository<Doctor>) repository;
        }

        public List<Doctor> Doctors { get; set; }
        public void OnGet()
        {
            Doctors = _repository.GetAll();
            Console.WriteLine("hello");
        }
    }
}
