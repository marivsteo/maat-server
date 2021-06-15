using Maat.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maat.DataAccess
{
    public class MaatDbContext : DbContext
    {
        public MaatDbContext(DbContextOptions<MaatDbContext> options) : base(options) { }

        public DbSet<SportEvent> SportEvents { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SportEventUser> SportEventUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });

            modelBuilder.Entity<SportEvent>()
                .HasMany(s => s.Users)
                .WithMany(s => s.SportEvents)
                .UsingEntity<SportEventUser>(
                    j => j
                        .HasOne(su => su.User)
                        .WithMany(u => u.SportEventUsers)
                        .HasForeignKey(su => su.UserId),
                    j => j
                        .HasOne(su => su.SportEvent)
                        .WithMany(s => s.SportEventUsers)
                        .HasForeignKey(su => su.SportEventId),
                    j =>
                    {
                        j.HasKey(p => new { p.SportEventId, p.UserId });
                    });

            modelBuilder.Entity<SportEvent>()
                .HasOne(p => p.CreatedBy)
                .WithMany(p => p.CreatedSportEvents);
        }
    }
}
