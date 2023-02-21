using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FootballService.Models
{
    public class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<Player> Players { get; set; }
    }
}
