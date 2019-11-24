using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScratchCards.Models;

namespace ScratchCards.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sign> Signs { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<MatchingConfiguration> MatchingConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(new Game
            { 
                Id = 1,
                Name = "ScratchCards",
                MaxNumberOfScratchCards = 4,
                ScratchCardSignsCanRepeat = true,
                SignsNumberOnScratchCard = 4,
                SignsNumberOnWheel = 3,
                UseJokerFeature = true
            });

            modelBuilder.Entity<MatchingConfiguration>().HasData(new MatchingConfiguration
            {
                GameId = 1,
                Id = 1,
                MatchingSignsCount = 1,
                Factor = 3
            },
            new MatchingConfiguration
            {
                GameId = 1,
                Id = 2,
                MatchingSignsCount = 2,
                Factor = 5
            },
            new MatchingConfiguration
            {
                GameId = 1,
                Id = 3,
                MatchingSignsCount = 3,
                Factor = 9
            },
            new MatchingConfiguration
            {
                GameId = 1,
                Id = 4,
                MatchingSignsCount = 4,
                Factor = 13
            });

            modelBuilder.Entity<Sign>().HasData(new Sign
            {
                GameId = 1,
                Id = 1,
                Name = "Sign 1",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 2,
                Name = "Sign 2",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 3,
                Name = "Sign 3",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 4,
                Name = "Sign 4",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 5,
                Name = "Sign 5",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 6,
                Name = "Sign 6",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 7,
                Name = "Sign 7",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 8,
                Name = "Sign 8",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 9,
                Name = "Sign 9",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 10,
                Name = "Sign 10",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 11,
                Name = "Sign 11",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 12,
                Name = "Sign 12",
                Special = false
            },
            new Sign
            {
                GameId = 1,
                Id = 13,
                Name = "Joker",
                Special = true
            });
        }
    }
}