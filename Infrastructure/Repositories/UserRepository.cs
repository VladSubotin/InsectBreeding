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
    public class UserRepository : IUserRepository
    {
        private readonly InsectBreedingDbContext insectBreedingDbContext;

        public UserRepository(InsectBreedingDbContext insectBreedingDbContext)
        {
            this.insectBreedingDbContext = insectBreedingDbContext;
        }
        public List<User> GetAll()
        {
            return insectBreedingDbContext.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return insectBreedingDbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(User user)
        {
            insectBreedingDbContext.Users.Add(user);
            insectBreedingDbContext.SaveChanges();
        }

        public void Update(User user)
        {
            insectBreedingDbContext.Users.Update(user);
            insectBreedingDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            insectBreedingDbContext.Users.Remove(user);
            insectBreedingDbContext.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return insectBreedingDbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return insectBreedingDbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
