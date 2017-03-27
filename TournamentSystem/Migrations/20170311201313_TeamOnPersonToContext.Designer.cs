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
    [Migration("20170311201313_TeamOnPersonToContext")]
    partial class TeamOnPersonToContext
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

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Firstname");

                    b.Property<DateTime>("LastChangedAt");

                    b.Property<string>("Lastname");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("TournamentSystem.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastChangedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TournamentSystem.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("LastChangedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("StartDate");

                    b.Property<int>("TournamentType");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentSystem.Models.Player", b =>
                {
                    b.HasBaseType("TournamentSystem.Models.Person");

                    b.Property<int>("TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");

                    b.HasDiscriminator().HasValue("Player");
                });

            modelBuilder.Entity("TournamentSystem.Models.Team", b =>
                {
                    b.HasOne("TournamentSystem.Models.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("TournamentSystem.Models.Player", b =>
                {
                    b.HasOne("TournamentSystem.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
