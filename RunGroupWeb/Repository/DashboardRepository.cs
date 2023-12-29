using Microsoft.AspNet.Identity;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;
using RunGroupWeb.Data.Interface;

namespace RunGroupWeb.Repository
{
    public class DashboardRepository : IDashboardRepository
    {

        readonly ApplicationDbContext _context;
        readonly IHttpContextAccessor _contextAccessor; // additional info about the current context we are in

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<IEnumerable<Club>> GetAllUserClubs()
        {
            var currentUser = _contextAccessor.HttpContext?.User;
            var clubs = _context.Clubs.Where(r => r.AppUserId == currentUser.Identity.GetUserId());
            return clubs;
        }

        public async Task<IEnumerable<Race>> GetAllUserRaces()
        {
            var currentUser = _contextAccessor.HttpContext?.User;
            var races = _context.Races.Where(r => r.AppUserId == currentUser.Identity.GetUserId());
            return races;
        }
    }
}
