using FootballService.Exceptions;
using FootballService.ErrorResponse;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballService.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : Controller
    {
        [Route("error")]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var path = feature?.Path;
            var error = feature?.Error;
            string message = null;
            var code = 500;

            if (error is HttpStatusException httpException)
                code = (int)httpException.Status;

            if (code == 500)
                message = "Внутрисерверная ошибка подключения.";
         
            Response.StatusCode = code;

            if (path.EndsWith("/AddTeam") || path.EndsWith("/EditPlayer") || path.EndsWith("/DeletePlayer"))
                return Json(new CustomErrorResponse(code, message ?? error.Message));

            ViewBag.Error = new CustomErrorResponse(code, message ?? error.Message);

            return View();
        }
    }
}
