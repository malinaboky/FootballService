using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FootballService.Models
{
    public class Player
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Sex { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [ForeignKey("Team")]
        public long TeamId { get; set; } 

        [Required]
        public string Country { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}
