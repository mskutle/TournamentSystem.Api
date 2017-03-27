using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.Models
{
    public class Tournament : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public virtual ICollection<Team> Teams { get; set; }
        public TournamentType TournamentType { get; set; }
    }
}