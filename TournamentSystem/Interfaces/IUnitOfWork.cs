using System;
using System.Threading.Tasks;

namespace TournamentSystem.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITournamentRepository Tournaments { get; }
        ITeamRepository Teams { get; }
        IPersonRepository Persons { get; }
        IPlayerRepository Players { get; }
        ICourtRepository Courts { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}