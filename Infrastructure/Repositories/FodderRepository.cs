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
    public class FodderRepository : IFodderRepository
    {
        private readonly InsectBreedingDbContext insectBreedingDbContext;
        public FodderRepository(InsectBreedingDbContext insectBreedingDbContext)
        {
            this.insectBreedingDbContext = insectBreedingDbContext;
        }

        public List<Fodder> GetAll()
        {
            return insectBreedingDbContext.Fodders.ToList();
        }

        public Fodder GetById(Guid id)
        {
            return insectBreedingDbContext.Fodders.FirstOrDefault(f => f.Id == id);
        }

        public List<Fodder> GetByUserId(Guid id)
        {
            return insectBreedingDbContext.Fodders.Where(f => f.UserId == id).ToList();
        }

        public void Insert(Fodder entity)
        {
            //var user = insectBreedingDbContext.Users.FirstOrDefault(u => u.Id == entity.UserId);
            //entity.User = user;
            insectBreedingDbContext.Fodders.Add(entity);
            //user.Fodders.Add(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Update(Fodder entity)
        {
            insectBreedingDbContext.Fodders.Update(entity);
            insectBreedingDbContext.SaveChanges();
        }

        public void Delete(Fodder entity)
        {
            //entity.User.Fodders.Remove(entity);
            insectBreedingDbContext.Fodders.Remove(entity);
            insectBreedingDbContext.SaveChanges();
        }
    }
}
