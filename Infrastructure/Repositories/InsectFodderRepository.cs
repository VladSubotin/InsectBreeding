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
    public class InsectFodderRepository : IInsectFodderRepository
    {
        private readonly InsectBreedingDbContext insectBreedingDbContext;
        public InsectFodderRepository(InsectBreedingDbContext insectBreedingDbContext)
        {
            this.insectBreedingDbContext = insectBreedingDbContext;
        }

        public InsectFodder GetById(Guid insectId, Guid fodderId)
        {
            return insectBreedingDbContext.InsectFodders.FirstOrDefault(f => f.InsectId == insectId && f.FodderId == fodderId);
        }

        public List<InsectFodder> GetByInsectId(Guid id)
        {
            return insectBreedingDbContext.InsectFodders.Where(f => f.InsectId == id).ToList();
        }

        public void Insert(InsectFodder entity)
        {
            insectBreedingDbContext.InsectFodders.Add(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Update(InsectFodder entity)
        {
            insectBreedingDbContext.InsectFodders.Update(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Delete(InsectFodder entity)
        {
            insectBreedingDbContext.InsectFodders.Remove(entity);
            insectBreedingDbContext.SaveChanges();
        }
    }
}
