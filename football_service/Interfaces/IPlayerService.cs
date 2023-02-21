using FootballService.DTO;
using FootballService.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballService.Interfaces
{
    public interface IPlayerService
    {
        Task SavePlayerToDB(PLayerDTO playerInfo, DatabaseContext context);

        Task<IEnumerable<IGrouping<long, EditPlayerDTO>>> GetList(DatabaseContext context);

        Task SetChanges(AddPlayerDTO playerInfo, DatabaseContext context);

        Task<EditPlayerDTO> GetPlayer(long id, DatabaseContext context);

        Task DeletePlayer(long id, DatabaseContext context);
    }
}
