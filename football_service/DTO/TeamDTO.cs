using FootballService.Attributes;

using System.ComponentModel.DataAnnotations;

namespace FootballService.DTO
{
    public class TeamDTO
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(40, ErrorMessage = "Слишком длинное название")]
        [TeamName]  
        public string NewTeam { get; set; }
    }
}
