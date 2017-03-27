using TournamentSystem.Models;

namespace TournamentSystem.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        void AddPlayerToTeam(Player player, int teamId);
    }
}