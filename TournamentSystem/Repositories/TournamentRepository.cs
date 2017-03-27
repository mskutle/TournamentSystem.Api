using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Repositories
{
    public class TournamentRepository : Repository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(TsContext context) : base(context)
        {
        }

        public IEnumerable<Team> GetTeamsParticipatingIn(Tournament tournament)
        {
            throw new NotImplementedException();
            //return TsContext.Teams.Where(x => x.Tournaments.Contains(tournament));
        }

        public async Task<Tournament> AddTeamToTournament(Team team, Tournament t)
        {
            /*
            var tournament = TsContext.Tournaments.Find(t);

            if (tournament.Teams.Contains(team))
                return tournament;

            TsContext.Attach(tournament);

            tournament.Teams.Add(team);
            tournament.LastChangedAt = DateTime.Now;

            //TsContext.Entry(tournament).CurrentValues.SetValues(tournament);

            await TsContext.SaveChangesAsync();

            return tournament; */
            throw new NotImplementedException();
        }

        public TsContext TsContext
        {
            get { return Context as TsContext; }
        }
    }
}