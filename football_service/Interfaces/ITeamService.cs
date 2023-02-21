using FootballService.DTO;
using FootballService.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballService.Interfaces
{
    public interface ITeamService
    {
        Task SaveTeamToDB(TeamDTO teamInfo, DatabaseContext context);
        Task<List<Team>> GetTeams(bool flag, DatabaseContext context);
    }
}
