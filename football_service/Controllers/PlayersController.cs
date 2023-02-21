using FootballService.DTO;
using FootballService.Interfaces;
using FootballService.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FootballService.Controllers
{
    public class PlayersController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IRazorPartialToStringRenderer _renderer;
        private readonly IPlayerService _playerService;

        public PlayersController(DatabaseContext context, 
            IRazorPartialToStringRenderer renderer,
            IPlayerService playerService)
        {
            _context = context;
            _renderer = renderer;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ViewBag.Teams = new SelectList(_context.Teams, "Id", "Name");

            return View(await _playerService.GetList(_context));
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer([FromBody] AddPlayerDTO playerInfo)
        {
            var flag = false;

            if (ModelState.IsValid)
            {
                await _playerService.SetChanges(playerInfo, _context);
                flag = true;
            }

            ViewBag.Teams = new SelectList(_context.Teams, "Id", "Name"); 
            ViewData.Model = await _playerService.GetPlayer(playerInfo.Id, _context);

            var body = await _renderer.RenderPartialToStringAsync<EditPlayerDTO>(this, "~/Views/Players/EditPlayer.cshtml");

            return Json(new { html = body, flag });
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer([FromBody] DeletePlayerDTO playerInfo)
        {
            if (ModelState.IsValid)
            {
                await _playerService.DeletePlayer(playerInfo.Id, _context);
            }

            return Ok();
        }
    }
}
