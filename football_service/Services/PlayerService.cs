using FootballService.DTO;
using FootballService.Exceptions;
using FootballService.Interfaces;
using FootballService.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FootballService.Services
{
    public class PlayerService: IPlayerService
    {
        public async Task SavePlayerToDB(PLayerDTO playerInfo, DatabaseContext context)
        {
            var player = new Player
            {
                TeamId = (long)playerInfo.TeamId,
                Name = playerInfo.Name,
                Surname = playerInfo.Surname,
                Sex = playerInfo.Sex.ToString(),
                Birthday = playerInfo.Birthday.Date,
                Country = playerInfo.Country.ToString()
            };

            context.Players.Add(player);

            try
            {
                await context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Ошибка сохранения.");
            } 
        }

        public async Task<IEnumerable<IGrouping<long, EditPlayerDTO>>> GetList(DatabaseContext context)
        {
            var players = await context.Players.Include(p => p.Team).Select(p => new EditPlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                Sex = p.Sex,
                Birthday = p.Birthday,
                TeamId = p.TeamId,
                Country = p.Country,
                Team = p.Team
            }).ToListAsync();

            return players.GroupBy(p => p.Team.Id);
        }

        public async Task SetChanges(AddPlayerDTO playerInfo, DatabaseContext context)
        {
            var player = await context.Players.FindAsync(playerInfo.Id);

            if (player == null)
                throw new HttpStatusException(HttpStatusCode.NotFound, "Игрок не найден.");

            player.Name = playerInfo.Name ?? player.Name;
            player.Surname = playerInfo.Surname ?? player.Surname;
            player.Sex = playerInfo.Sex == null ? player.Sex : playerInfo.Sex.ToString();
            player.Birthday = playerInfo.Birthday == null ? player.Birthday : DateTime.Parse(playerInfo.Birthday);
            player.Country = playerInfo.Country == null ? player.Country : playerInfo.Country.ToString();
            player.TeamId = playerInfo.TeamId == null ? player.TeamId : (long)playerInfo.TeamId;

            context.Entry(player).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Ошибка сохранения.");
            }
        }

        public async Task<EditPlayerDTO> GetPlayer(long id, DatabaseContext context)
        {
            var player = await context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == id);

            if (player == null)
                throw new HttpStatusException(HttpStatusCode.NotFound, "Игрок не найден.");

            return new EditPlayerDTO
            {
                Id = player.Id,
                Name = player.Name,
                Surname = player.Surname,
                Sex = player.Sex,
                Birthday = player.Birthday,
                TeamId = player.TeamId,
                Country = player.Country,
                Team = player.Team
            };
        }

        public async Task DeletePlayer(long id, DatabaseContext context)
        {
            var player = await context.Players.FindAsync(id);

            if (player == null)
                throw new HttpStatusException(HttpStatusCode.NotFound, "Игрок не найден.");

            context.Players.Remove(player);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Ошибка сохранения.");
            }
        }
    }
}
