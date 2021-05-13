using System;
using System.Collections.Generic;
using System.Text;
using HockeyPool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BettingSiteCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Matchup> Matchups { get; set; }
        public DbSet<PlayerTournament> PlayerTournaments { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
