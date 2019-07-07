using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext:DbContext
    {
        public DbSet<Team> Teams  { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigTeamModel(modelBuilder);
            ConfigColorModel(modelBuilder);
            ConfigGameModel(modelBuilder);
            ConfigTownModel(modelBuilder);
            ConfigPlayerModel(modelBuilder);
            ConfigPostionModel(modelBuilder);
            ConfigPlayerStatisticModel(modelBuilder);
            ConfigBetModel(modelBuilder);
            ConfigUserModel(modelBuilder);
            ConfigCountryModel(modelBuilder);
        }

        private void ConfigCountryModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Country>()
                .HasKey(x => x.CountryId);
        }

        private void ConfigUserModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasKey(x => x.UserId);
        }

        private void ConfigBetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Bet>(entity =>
                {
                    entity.HasKey(x => x.BetId);

                    entity.HasOne(g => g.Game).WithMany(b => b.Bets);

                    entity.Property(p => p.Prediction).IsRequired(true);

                    entity.HasOne(u => u.User).WithMany(b => b.Bets);
                });
        }

        private void ConfigPlayerStatisticModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PlayerStatistic>(entity =>
                {
                    entity.HasKey(x => new
                    {
                        x.PlayerId,
                        x.GameId
                    });

                    entity
                        .HasOne(x => x.Player)
                        .WithMany(s => s.PlayerStatistics)
                        .HasForeignKey(k=>k.PlayerId);

                    entity
                        .HasOne(g => g.Game)
                        .WithMany(p => p.PlayerStatistics)
                        .HasForeignKey(k => k.GameId);
                });
        }

        private void ConfigPostionModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Position>(entity => 
                {
                    entity.HasKey(x => x.PositionId);

                    entity.HasMany(p => p.Players).WithOne(x => x.Position);
                });
        }

        private void ConfigPlayerModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Player>(entity => 
                {
                    entity.HasKey(x => x.PlayerId);

                    entity.HasOne(t => t.Team).WithMany(p => p.Players);
                });
        }

        private void ConfigTownModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Town>(entity => 
                {
                    entity.HasKey(x => x.TownId);

                    entity.HasOne(c => c.Country).WithMany(t => t.Towns);
                });
        }

        private void ConfigGameModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>(entity => 
                {
                    entity.HasKey(x => x.GameId);

                    entity.HasOne(x => x.HomeTeam).WithMany(g => g.HomeGames).OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(x => x.AwayTeam).WithMany(g => g.AwayGames).OnDelete(DeleteBehavior.Restrict);
                });
        }

        private void ConfigColorModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(x => x.ColorId);
                
            });
        }

        private void ConfigTeamModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(x => x.TeamId);

                entity
                    .HasOne(x => x.PrimaryKitColor)
                    .WithMany(y => y.PrimaryKitColors)
                    .HasForeignKey(k=>k.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(x => x.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitColors)
                    .HasForeignKey(k => k.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Town).WithMany(x => x.Teams);
            });

        }
    }
}
