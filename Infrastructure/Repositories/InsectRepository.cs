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
    public class InsectRepository : IInsectRepository
    {
        private readonly InsectBreedingDbContext insectBreedingDbContext;
        public InsectRepository(InsectBreedingDbContext insectBreedingDbContext)
        {
            this.insectBreedingDbContext = insectBreedingDbContext;
        }

        public List<Insect> GetAll()
        {
            return insectBreedingDbContext.Insects.ToList();
        }

        public Insect GetById(Guid id)
        {
            return insectBreedingDbContext.Insects.FirstOrDefault(f => f.Id == id);
        }

        public List<Insect> GetByUserId(Guid id)
        {
            return insectBreedingDbContext.Insects.Where(f => f.UserId == id).ToList();
        }

        public void Insert(Insect entity)
        {
            insectBreedingDbContext.Insects.Add(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Update(Insect entity)
        {
            insectBreedingDbContext.Insects.Update(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Delete(Insect entity)
        {
            insectBreedingDbContext.Insects.Remove(entity);
            insectBreedingDbContext.SaveChanges();
        }
    }
}
