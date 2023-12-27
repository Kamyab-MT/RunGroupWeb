using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;
using RunGroupWeb.Data.Interface;

namespace RunGroupsWeb.Controllers
{
    public class ClubController : Controller
    {

        IClubRepository _club;

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
    }
}
