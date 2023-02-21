using System.ComponentModel.DataAnnotations;

namespace FootballService.Models
{
    public enum Sex
    {
        [Display(Name = "Мужской")]
        Male,
        [Display(Name = "Женский")]
        Female
    }
}
