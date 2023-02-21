using FootballService.Models;

using System.ComponentModel.DataAnnotations;
using System;

namespace FootballService.DTO
{
    public class EditPlayerDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public long TeamId { get; set; }

        public string Country { get; set; }

        public virtual Team Team { get; set; }
    }
}
