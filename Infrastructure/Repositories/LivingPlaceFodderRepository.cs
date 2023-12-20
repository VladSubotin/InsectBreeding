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
    public class LivingPlaceFodderRepository : ILivingPlaceFodderRepository
    {
        private readonly InsectBreedingDbContext insectBreedingDbContext;
        public LivingPlaceFodderRepository(InsectBreedingDbContext insectBreedingDbContext)
        {
            this.insectBreedingDbContext = insectBreedingDbContext;
        }

        public LivingPlaseFodder GetById(Guid livingPlaseId, Guid fodderId)
        {
            return insectBreedingDbContext.LivingPlaseFodders.FirstOrDefault(f => f.LivingPlaseId == livingPlaseId && f.FodderId == fodderId);
        }

        public List<LivingPlaseFodder> GetByLivingPlaceId(Guid id)
        {
            return insectBreedingDbContext.LivingPlaseFodders.Where(f => f.LivingPlaseId == id).ToList();
        }

        public void Insert(LivingPlaseFodder entity)
        {
            insectBreedingDbContext.LivingPlaseFodders.Add(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Update(LivingPlaseFodder entity)
        {
            insectBreedingDbContext.LivingPlaseFodders.Update(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Delete(LivingPlaseFodder entity)
        {
            insectBreedingDbContext.LivingPlaseFodders.Remove(entity);
            insectBreedingDbContext.SaveChanges();
        }
    }
}
