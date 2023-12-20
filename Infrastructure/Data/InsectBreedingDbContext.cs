using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class InsectBreedingDbContext : DbContext, IInsectBreedingDbContext
    {
        public InsectBreedingDbContext(DbContextOptions<InsectBreedingDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insect>()
                .HasOne(i => i.User)
                .WithMany(u => u.Insects)
                .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<Fodder>()
                .HasOne(f => f.User)
                .WithMany(u => u.Fodders)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<LivingPlace>()
                .HasOne(l => l.User)
                .WithMany(u => u.LivingPlaces)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<InsectFodder>()
                .HasKey(g => new { g.InsectId, g.FodderId });

            modelBuilder.Entity<InsectLivingPlase>()
                .HasKey(g => new { g.InsectId, g.LivingPlaseId });

            modelBuilder.Entity<LivingPlaseFodder>()
                .HasKey(g => new { g.LivingPlaseId, g.FodderId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Insect> Insects { get; set; }
        public DbSet<Fodder> Fodders { get; set; }
        public DbSet<LivingPlace> LivingPlaces { get; set; }
        public DbSet<InsectFodder> InsectFodders { get; set; }
        public DbSet<InsectLivingPlase> InsectLivingPlases { get; set; }
        public DbSet<LivingPlaseFodder> LivingPlaseFodders { get; set; }
    }
}
