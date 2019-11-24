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
    }
}