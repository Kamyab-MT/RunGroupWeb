using Microsoft.EntityFrameworkCore;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;
using RunGroupWeb.Data.Interface;

namespace RunGroupWeb.Repository
{
    public class ClubRepository : IClubRepository
    {

        ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool Add(Club club)
        {
            _context.Clubs.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Clubs.Remove(club);
            return Save();
        }

        public bool Update(Club club)
        {
            _context.Clubs.Update(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll() => await _context.Clubs.ToListAsync();

        public async Task<Club> GetByIdAsync(int id) => await _context.Clubs.Include(b => b.Address).FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IEnumerable<Club>> GetCloubByCity(string city) => await _context.Clubs.Where(a => a.Address.City.Contains(city)).ToListAsync();

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
