using FootballService.Exceptions;
using FootballService.Models;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;

namespace FootballService.Attributes
{
    public class TeamNameAttribute : ValidationAttribute
    {
        public string GetErrorMessage(string name) =>
            $"Название {name} уже занято";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var context = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));
            var team = (string)value;

            try
            {
                var oldTeam = context.Teams.Any(t => t.Name.ToLower().Replace(" ", "") == team.ToLower().Replace(" ", ""));
                if (oldTeam)
                {
                    return new ValidationResult(GetErrorMessage(team));
                }

                return ValidationResult.Success;
            }
            catch
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Внутрисерверная ошибка подключения.");
            }   
        }
    }
}
