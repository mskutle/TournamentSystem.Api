using Microsoft.EntityFrameworkCore;
using TournamentSystem.Models;

namespace TournamentSystem
{
    public class TsContext : DbContext
    {
        public TsContext(DbContextOptions<TsContext> options) : base(options)
        {
        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Court> Courts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<TournamentTeam>()
                .HasKey(tt => new {tt.TeamId, tt.TournamentId});

            modelBuilder.Entity<TournamentTeam>()
                .HasOne(tt => tt.Team)
                .WithMany(team => team.TournamentTeams)
                .HasForeignKey(tt => tt.TeamId);

            modelBuilder.Entity<TournamentTeam>()
                .HasOne(tt => tt.Tournament)
                .WithMany(tournament => tournament.TournamentTeams)
                .HasForeignKey(tt => tt.TournamentId);
            */

            modelBuilder.Entity<Player>()
                .HasOne(x => x.Team)
                .WithMany(x => x.Players);

            modelBuilder.Entity<Team>()
                .HasMany(x => x.Players)
                .WithOne(x => x.Team);

            base.OnModelCreating(modelBuilder);
        }
    }
}