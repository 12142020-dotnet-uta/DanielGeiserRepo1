using Microsoft.EntityFrameworkCore;
using System;

namespace RpsGame_refactored_Db
{
    public class RpsDbContext : DbContext
    {
        public DbSet<Player> players {get; set;}
        public DbSet<Match> matches {get; set;}
        public DbSet<Round> rounds {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=LocalHost\\SQLEXPRESS01;Database=Rps12142020;Trusted_Connection=True;");
        }

    }
}