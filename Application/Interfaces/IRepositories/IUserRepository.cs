using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(Guid id);
        void Insert(User entity);
        void Update(User entity);
        void Delete(User entity);
        public User GetByEmail(string email);
        public User GetByEmailAndPassword(string email, string password);
    }
}
