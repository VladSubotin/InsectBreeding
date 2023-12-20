using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Entities.Requests;
using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthenticateRepository authenticateRepository;

        public UserService(IUserRepository userRepository, IAuthenticateRepository authenticateRepository)
        {
            this.userRepository = userRepository;
            this.authenticateRepository = authenticateRepository;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            users = userRepository.GetAll();
            return users;
        }

        public User GetById(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Incorrect id format");
            }

            User user = userRepository.GetById(parsedId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public Guid GetIdFromToken(string token)
        {
            Guid id = authenticateRepository.GetUserIdFromToken(token);
            return id;
        }

        public void Insert(CreateUser createUser)
        {
            if (userRepository.GetByEmail(createUser.Email) != null)
            {
                throw new Exception("Email is already taken.");
            }

            var user = new User
            {
                Email = createUser.Email,
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Password = createUser.Password,
                Role = createUser.Role
            };

            userRepository.Insert(user);
        }

        public void Update(UpdateUser updateUser)
        {
            var user = GetById(updateUser.Id);

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Password = updateUser.Password;

            userRepository.Update(user);
        }

        public void Delete(string id)
        {
            var user = GetById(id);

            userRepository.Delete(user);
        }
        public User GetByEmail(string email)
        {
            return userRepository.GetByEmail(email);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return userRepository.GetByEmailAndPassword(email, password);
        }

        public string Login(LoginUser loginUser)
        {
            if (GetByEmail(loginUser.Email) == null)
            {
                throw new Exception("Incorrect email.");
            }

            var user = new User();

            user = GetByEmailAndPassword(loginUser.Email, loginUser.Password);
            if (user == null)
            {
                throw new Exception("Incorrect password.");
            }

            return authenticateRepository.Authenticate(user);
        }
    }
}
