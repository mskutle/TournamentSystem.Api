using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.ViewModels {

    public class PlayerViewModel {
        
        [Required]
        public int Id { get; set;}
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}