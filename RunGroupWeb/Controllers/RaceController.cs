using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;

namespace RunGroupsWeb.Controllers
{
    public class RaceController : Controller
    {

        ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }

        public IActionResult Details(int? id)
        {
            Race club = _context.Races.Include(b => b.Address).FirstOrDefault(t => t.Id == id);
            return View(club);
        }
    }
}
