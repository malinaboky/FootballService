using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FootballService.Interfaces
{
    public interface IRazorPartialToStringRenderer
    {
        Task<string> RenderPartialToStringAsync<TModel>(Controller controller, string partialName);
    }
}
