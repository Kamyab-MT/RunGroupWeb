using RunGroupsWeb.Models;

namespace RunGroupWeb.Data.Interface
{
    public interface IClubRepository
    {

        public Task<IEnumerable<Club>> GetAll();
        public Task<Club> GetByIdAsync(int id);
        public Task<IEnumerable<Club>> GetCloubByCity(string city);
        bool Add (Club club);
        bool Update (Club club);
        bool Delete (Club club);
        bool Save ();
    }
}
