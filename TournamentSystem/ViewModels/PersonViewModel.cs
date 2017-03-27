using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.ViewModels {

    public class PersonViewModel {
        
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}