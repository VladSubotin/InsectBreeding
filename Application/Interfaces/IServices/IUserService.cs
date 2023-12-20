using Application.Entities.Requests;
using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(string token);
        public Guid GetIdFromToken(string token);
        void Insert(CreateUser createUser);
        void Update(UpdateUser updateUser);
        void Delete(string id);
        public User GetByEmail(string email);
        public User GetByEmailAndPassword(string email, string password);
        public string Login(LoginUser loginUser);
    }
}
