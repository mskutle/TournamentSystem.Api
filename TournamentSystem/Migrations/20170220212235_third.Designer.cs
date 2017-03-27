using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TournamentSystem;
using TournamentSystem.Models;

namespace TournamentSystem.Migrations
{
    [DbContext(typeof(TsContext))]
    [Migration("20170220212235_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TournamentSystem.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastChangedAt");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Courts");
                });

            modelBuilder.Entity("TournamentSystem.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Firstname");

                    b.Property<DateTime>("LastChangedAt");

                    b.Property<string>("Lastname");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("TournamentSystem.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastChangedAt");

                    b.Property<string>("Name");

                    b.Property<int?>("OwnerId");

                    b.Property<int?>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TournamentSystem.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("LastChangedAt");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfTeams");

                    b.Property<DateTime?>("StartDate");

                    b.Property<int?>("TeamId");

                    b.Property<int>("TournamentType");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentSystem.Models.Person", b =>
                {
                    b.HasOne("TournamentSystem.Models.Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("TournamentSystem.Models.Team", b =>
                {
                    b.HasOne("TournamentSystem.Models.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("TournamentSystem.Models.Tournament")
                        .WithMany("Teams")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("TournamentSystem.Models.Tournament", b =>
                {
                    b.HasOne("TournamentSystem.Models.Team")
                        .WithMany("Tournaments")
                        .HasForeignKey("TeamId");
                });
        }
    }
}
