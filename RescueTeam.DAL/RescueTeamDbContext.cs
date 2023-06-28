using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RescueTeam.DAL.Entities;

namespace RescueTeam.DAL
{
    public class RescueTeamDbContext:DbContext
    {
        public DbSet<Mission> Missions { get; set; }
        public DbSet<TeamMember>  TeamMembers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        public RescueTeamDbContext()
        {
        }

        public RescueTeamDbContext(DbContextOptions<RescueTeamDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<TeamMember>() 
                .HasOne<Team>(tm => tm.Team) 
                .WithMany(t => t.TeamMembers) 
                .HasForeignKey(tm => tm.CurrentTeamId) //non convenzione, va esplicitata per naming
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Trasport)
                .WithOne(v => v.AssignedTeam)
                .HasForeignKey<Team>(t => t.TransportID);
        }



        //solo per demo hard connection strings
        //in compile time capisce che deve usare sql server DB
        //e la connection string

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //collegamento col provider
                optionsBuilder.UseSqlServer(
                    "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RescueTeamDatabase");
            }

           
        }
    }
}
