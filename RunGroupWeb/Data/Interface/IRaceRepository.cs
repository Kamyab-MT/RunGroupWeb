using RunGroupsWeb.Models;

namespace RunGroupWeb.Data.Interface
{
    public interface IRaceRepository
    {
        public Task<IEnumerable<Race>> GetAll();
        public Task<Race> GetByIdAsync(int id);
        public Task<IEnumerable<Race>> GetRaceByCity(string city);
        bool Add(Race club);
        bool Update(Race club);
        bool Delete(Race club);
        bool Save();
    }
}
