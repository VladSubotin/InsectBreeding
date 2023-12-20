using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LivingPlaceRepository : ILivingPlaceRepository
    {
        private readonly InsectBreedingDbContext insectBreedingDbContext;
        public LivingPlaceRepository(InsectBreedingDbContext insectBreedingDbContext)
        {
            this.insectBreedingDbContext = insectBreedingDbContext;
        }

        public List<LivingPlace> GetAll()
        {
            return insectBreedingDbContext.LivingPlaces.ToList();
        }

        public LivingPlace GetById(Guid id)
        {
            return insectBreedingDbContext.LivingPlaces.FirstOrDefault(f => f.Id == id);
        }

        public List<LivingPlace> GetByUserId(Guid id)
        {
            return insectBreedingDbContext.LivingPlaces.Where(f => f.UserId == id).ToList();
        }

        public void Insert(LivingPlace entity)
        {
            insectBreedingDbContext.LivingPlaces.Add(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Update(LivingPlace entity)
        {
            insectBreedingDbContext.LivingPlaces.Update(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Delete(LivingPlace entity)
        {
            insectBreedingDbContext.LivingPlaces.Remove(entity);
            insectBreedingDbContext.SaveChanges();
        }
    }
}
