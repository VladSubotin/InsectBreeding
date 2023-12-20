using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IInsectBreedingDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Insect> Insects { get; set; }
        public DbSet<Fodder> Fodders { get; set; }
        public DbSet<LivingPlace> LivingPlaces { get; set; }
        public DbSet<InsectFodder> InsectFodders { get; set; }
        public DbSet<InsectLivingPlase> InsectLivingPlases { get; set; }
        public DbSet<LivingPlaseFodder> LivingPlaseFodders { get; set; }
    }
}
