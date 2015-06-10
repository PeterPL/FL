using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.EF
{
   public class FootballContext : DbContext
    {
        public FootballContext(): base("name=FootballContextConnection")
            {
            
            }
       public DbSet<Match> Matches { get; set; }
       public DbSet<Club> Clubs { get; set; }
       public DbSet<Player> Players { get; set; }
       public DbSet<Position> Positions { get; set; }
       public DbSet<Event> Events { get; set; }
       public DbSet<EventKind> EventKinds { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           //Configure domain classes using Fluent API here

           modelBuilder.Entity<Player>().HasRequired(p => p.Club).WithMany().WillCascadeOnDelete(false);
       }
    }
}
