using FootballService.DTO;
using FootballService.Models;
using FootballService.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace FootballService.Controllers
{
    public class MainPageController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public MainPageController( DatabaseContext context,
            ITeamService teamService,
            IPlayerService playerService)
        {
            _context = context;
            _teamService = teamService;
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult AddPlayer()
        {
            ViewBag.TeamId = new SelectList(_context.Teams, "Id", "Name");

            return PartialView("AddPlayer");
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(PLayerDTO player)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SuccessMessage = "Игрок успешно добавлен";
                await _playerService.SavePlayerToDB(player, _context);
                ModelState.Clear();
            }

            ViewBag.TeamId = new SelectList(_context.Teams, "Id", "Name");

            return PartialView("AddPlayer");
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam([FromBody] TeamDTO team)
        {
            if (ModelState.IsValid)
            {
                 await _teamService.SaveTeamToDB(team, _context);
            }

            ViewBag.TeamId = new SelectList(await _teamService.GetTeams(ModelState.IsValid, _context), "Id", "Name");
            return PartialView("AddTeam", team);
        }

        [HttpGet]
        public IActionResult RedirectAction()
        {
            return View();
        }

    }
}
