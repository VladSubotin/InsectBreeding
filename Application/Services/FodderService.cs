using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FodderService : IFodderService
    {
        private readonly IFodderRepository fodderRepository;
        public FodderService(IFodderRepository fodderRepository)
        {
            this.fodderRepository = fodderRepository;
        }
        public List<Fodder> GetAll()
        {
            List<Fodder> fodders = new List<Fodder>();
            fodders = fodderRepository.GetAll();

            return fodders;
        }

        public Fodder GetById(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            Fodder fodder = fodderRepository.GetById(parsedId);
            if (fodder == null)
            {
                throw new Exception("Fodder not found");
            }

            return fodder;
        }

        public List<Fodder> GetByUserId(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            List<Fodder> fodders = new List<Fodder>();
            fodders = fodderRepository.GetByUserId(parsedId);

            return fodders;
        }

        public void Insert(CreateFodder createFodder)
        {
            var fodder = new Fodder
            {
                Name = createFodder.Name,
                Description = createFodder.Description,
                UserId = createFodder.UserId
            };

            fodderRepository.Insert(fodder);
        }

        public void Update(UpdateFodder updateFodder)
        {
            var fodder = GetById(updateFodder.Id);
            fodder.Name = updateFodder.Name;
            fodder.Description = updateFodder.Description;

            fodderRepository.Update(fodder);
        }

        public void Delete(string id)
        {
            var fodder = GetById(id);

            fodderRepository.Delete(fodder);
        }
    }
}
