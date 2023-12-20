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
    public class InsectLivingPlaceRepository : IInsectLivingPlaceRepository
    {
        private readonly InsectBreedingDbContext insectBreedingDbContext;
        public InsectLivingPlaceRepository(InsectBreedingDbContext insectBreedingDbContext)
        {
            this.insectBreedingDbContext = insectBreedingDbContext;
        }

        public InsectLivingPlase GetById(Guid insectId, Guid livingPlaseId)
        {
            return insectBreedingDbContext.InsectLivingPlases.FirstOrDefault(f => f.InsectId == insectId && f.LivingPlaseId == livingPlaseId);
        }

        public List<InsectLivingPlase> GetByLivingPlaceId(Guid id)
        {
            return insectBreedingDbContext.InsectLivingPlases.Where(f => f.LivingPlaseId == id).ToList();
        }

        public void Insert(InsectLivingPlase entity)
        {
            insectBreedingDbContext.InsectLivingPlases.Add(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Update(InsectLivingPlase entity)
        {
            insectBreedingDbContext.InsectLivingPlases.Update(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Delete(InsectLivingPlase entity)
        {
            insectBreedingDbContext.InsectLivingPlases.Remove(entity);
            insectBreedingDbContext.SaveChanges();
        }
    }
}
