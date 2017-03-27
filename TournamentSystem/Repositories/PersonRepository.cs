using Microsoft.EntityFrameworkCore;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}