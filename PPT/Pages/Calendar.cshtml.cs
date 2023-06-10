using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace PPT.Pages
{
    [Authorize(Roles = "Secretary")]
    public class CalendarModel : PageModel
    {
        public void OnGet()
        {
        }

    }
}
