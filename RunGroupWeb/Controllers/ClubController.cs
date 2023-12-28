using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;
using RunGroupWeb.Data.Interface;

namespace RunGroupsWeb.Controllers
{
    public class ClubController : Controller
    {

        readonly IClubRepository _club;

        public ClubController(IClubRepository clubRepository)
        {
            _club = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _club.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Details(int id)
        {
            Club club = await _club.GetByIdAsync(id);
            return View(club);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if (!ModelState.IsValid)
                return View(club);

            _club.Add(club);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Club club = await _club.GetByIdAsync(id);

            if (club == null)
                return View("Error");

			return View(club);
		}

        [HttpPost]
        public async Task<IActionResult> Edit(Club club)
        {

            if (!ModelState.IsValid)
				return View(club);

            _club.Update(club);
            return RedirectToAction("Index");
		}

        public async Task<IActionResult> Delete(int id)
        {
            Club club = await _club.GetByIdAsync(id);

            if (club == null)
                return View("Error");

            return View(club);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Club club)
        {
            _club.Delete(club);
            return RedirectToAction("Index");
        }

    }
}
