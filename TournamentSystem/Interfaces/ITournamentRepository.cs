using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentSystem.Models;

namespace TournamentSystem.Interfaces
{
    public interface ITournamentRepository : IRepository<Tournament>
    {
        IEnumerable<Team> GetTeamsParticipatingIn(Tournament tournament);
        Task<Tournament> AddTeamToTournament(Team team, Tournament tournament);
    }
}