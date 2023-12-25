using Microsoft.AspNetCore.Mvc;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;

namespace RunGroupsWeb.Controllers
{
    public class ClubController : Controller
    {

        ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }
    }
}
