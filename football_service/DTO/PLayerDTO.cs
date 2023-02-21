using FootballService.Models;

using System.ComponentModel.DataAnnotations;
using System;

namespace FootballService.DTO
{
    public class PLayerDTO
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я''-'\s]{1,21}$", ErrorMessage = "Неправильный формат имени")]
        [StringLength(20, ErrorMessage = "Слишком длинное имя")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я''-'\s]{1,21}$", ErrorMessage = "Неправильный формат фамилии")]
        [StringLength(20, ErrorMessage = "Слишком длинная фамилия")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public long? TeamId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public Country Country { get; set; }
    }
}
