using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;
using RunGroupWeb.Data.Interface;

namespace RunGroupsWeb.Controllers
{
    public class RaceController : Controller
    {

        readonly IRaceRepository _race;

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

        public async Task<IActionResult> Edit(int id)
        {
            Race club = await _race.GetByIdAsync(id);

            if (club == null)
                return View("Error");

            return View(club);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Race race)
        {

            if (!ModelState.IsValid)
                return View(race);

            _race.Update(race);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Race club = await _race.GetByIdAsync(id);

            if (club == null)
                return View("Error");

            return View(club);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Race club)
        {

            if (!ModelState.IsValid)
                return View(club);

            _race.Delete(club);
            return RedirectToAction("Index");
        }
    }
}
