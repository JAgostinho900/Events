using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;

namespace ProEvents.Persistence.Contexts
{
    public class ProEventContext : DbContext
    {
        public ProEventContext(DbContextOptions<ProEventContext> options) : base(options) {
            
        }

        //For Migrations
        //dotnet ef migrations add [name of migration - ex: initialMigration]
        public DbSet<Event> Events { get; set; }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }

        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<SpeakerEvent>()
            .HasKey(SE => new { SE.EventId, SE.SpeakerId});

            // If we delete an Event, delete socialNetworks also. This happens because social networks have both foreign keys EventId and SpeakerId
            modelBuilder.Entity<Event>()
            .HasMany(e => e.SocialNetworks)
            .WithOne(sn => sn.Event)
            .OnDelete(DeleteBehavior.Cascade);

             modelBuilder.Entity<Speaker>()
            .HasMany(e => e.SocialNetworks)
            .WithOne(sn => sn.Speaker)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}