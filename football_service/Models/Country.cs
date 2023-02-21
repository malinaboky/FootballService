using System.ComponentModel.DataAnnotations;

namespace FootballService.Models
{
    public enum Country
    {
        [Display(Name = "Россия")]
        Russia,
        [Display(Name = "США")]
        USA,
        [Display(Name = "Италия")]
        Italy
    }
}
