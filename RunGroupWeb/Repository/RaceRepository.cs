using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;
using RunGroupWeb.Data.Interface;

namespace RunGroupWeb.Repository
{
    public class RaceRepository : IRaceRepository
    {

        ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public bool Update(Race race)
        {
            _context.Update(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll() => await _context.Races.ToListAsync();

        public async Task<Race> GetByIdAsync(int id) => await _context.Races.Include(b => b.Address).FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IEnumerable<Race>> GetRaceByCity(string city) => await _context.Races.Where(a => a.Address.City.Contains(city)).ToListAsync();

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
