using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.Models
{
    public class Person : BaseEntity
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}