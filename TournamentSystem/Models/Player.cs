
namespace TournamentSystem.Models
{
    public class Player : Person
    {
        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}