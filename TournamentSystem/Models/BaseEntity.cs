using System;

namespace TournamentSystem.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastChangedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            LastChangedAt = DateTime.Now;
        }
    }
}