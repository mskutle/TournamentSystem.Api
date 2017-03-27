using Microsoft.EntityFrameworkCore;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(DbContext context) : base(context)
        {
        }

        public void AddPlayerToTeam(Player player, int teamId)
        {
            var p = Context.Set<Player>().Find(player);

            Context.Set<Player>().Attach(p);
            p.TeamId = teamId;
        }
    }
}