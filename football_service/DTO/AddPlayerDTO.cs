using FootballService.Models;

using System.ComponentModel.DataAnnotations;

namespace FootballService.DTO
{
    public class AddPlayerDTO
    {
        public long Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]{1,21}$")]
        [StringLength(20, ErrorMessage = "Слишком длинное имя")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Zа-яА-Я''-'\s]{1,21}$")]
        [StringLength(20, ErrorMessage = "Слишком длинная фамилия")]
        public string Surname { get; set; }

        public Sex? Sex { get; set; }

        public string Birthday { get; set; }

        public long? TeamId { get; set; }

        public Country? Country { get; set; }
    }
}
