using Microsoft.EntityFrameworkCore;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Repositories
{
    public class CourtRepository : Repository<Court>, ICourtRepository
    {
        public CourtRepository(DbContext context) : base(context)
        {
        }
    }
}