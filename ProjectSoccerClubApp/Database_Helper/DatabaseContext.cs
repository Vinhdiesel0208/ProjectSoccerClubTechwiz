using Microsoft.EntityFrameworkCore;
using ProjectModels;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;


namespace ProjectSoccerClubApp.Database_Helper
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Result> Result { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string str = "server=DESKTOP-T6R536I\\SQLEXPRESS01; database=MiamiDb; uid=sa; pwd=123; TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(str);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany()
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Match>()
                .HasOne(m => m.Result)
                .WithOne(r => r.Match)
                .HasForeignKey<Result>(r => r.MatchId);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Match)
                .WithOne(m => m.Result)
                .HasForeignKey<Result>(r => r.MatchId);
        }

    }
}
