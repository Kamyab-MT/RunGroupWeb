using RunGroupsWeb.Models;
using System.Collections;

namespace RunGroupWeb.Data.Interface
{
    public interface IDashboardRepository
    {

        public Task<IEnumerable<Club>> GetAllUserClubs();
        public Task<IEnumerable<Race>> GetAllUserRaces();
    }
}
