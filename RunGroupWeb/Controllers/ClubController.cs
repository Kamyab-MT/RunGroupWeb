using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Details(int? id)
        {
            Club club = _context.Clubs.Include(b => b.Address).FirstOrDefault(t => t.Id == id);
            return View(club);
        }
    }
}
