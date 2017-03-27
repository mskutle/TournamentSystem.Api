using Microsoft.EntityFrameworkCore;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext context) : base(context)
        {
        }
    }
}
