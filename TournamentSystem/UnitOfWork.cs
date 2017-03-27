using System.Threading.Tasks;
using TournamentSystem.Interfaces;
using TournamentSystem.Repositories;

namespace TournamentSystem
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TsContext _context;

        public ITournamentRepository Tournaments { get; set; }
        public ITeamRepository Teams { get; set; }
        public IPersonRepository Persons { get; set; }
        public IPlayerRepository Players { get; }
        public ICourtRepository Courts { get; set; }

        public UnitOfWork(TsContext context)
        {
            _context = context;
            Tournaments = new TournamentRepository(_context);
            Teams = new TeamRepository(_context);
            Persons = new PersonRepository(_context);
            Players = new PlayerRepository(_context);
            Courts = new CourtRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}