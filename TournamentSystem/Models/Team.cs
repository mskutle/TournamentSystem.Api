using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.Models
{
    public class Team : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Person Owner { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        //public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}