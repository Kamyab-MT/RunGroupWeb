using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;
using RunGroupWeb.Data.Interface;

namespace RunGroupsWeb.Controllers
{
    public class RaceController : Controller
    {

        IRaceRepository _race;

        public RaceController(IRaceRepository race)
        {
            _race = race;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _race.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Details(int id)
        {
            Race club = await _race.GetByIdAsync(id);
            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }

            _race.Add(race);
            return RedirectToAction("Index");

        }
    }
}
