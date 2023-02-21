using FootballService.DTO;
using FootballService.Exceptions;
using FootballService.Interfaces;
using FootballService.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FootballService.Services
{
    public class TeamService : ITeamService
    {
        public async Task SaveTeamToDB(TeamDTO teamInfo, DatabaseContext context)
        {
            var team = new Team
            {
                Name = teamInfo.NewTeam
            };

            context.Teams.Add(team);

            try
            {          
                await context.SaveChangesAsync();
            }
            catch 
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Ошибка сохранения.");
            }
        }

        public async Task<List<Team>> GetTeams(bool flag, DatabaseContext context)
        {
            var teams = await context.Teams.ToListAsync();

            if (flag)
            {
                (teams[^1], teams[0]) = (teams[0], teams[^1]);
            }

            return teams;
        }
    }
}
