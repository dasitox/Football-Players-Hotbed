using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FootballPlayersHotbed.EFModels
{
    public partial class FootballPlayersHotbedContext : DbContext
    {
        public FootballPlayersHotbedContext()
        {
        }

        public FootballPlayersHotbedContext(DbContextOptions<FootballPlayersHotbedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Representative> Representative { get; set; }
        public virtual DbSet<Team> Team { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Club)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DominanFood)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Representative)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerID).HasColumnName("PlayerID");
            });

            modelBuilder.Entity<Representative>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentativeRegistration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentativeID).HasColumnName("RepresentativeID");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NickNameTeam)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.StadiumName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TeamName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TeamID).HasColumnName("TeamID");
            });
        }
    }
}
