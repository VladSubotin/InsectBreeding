using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Interfaces.IServices;
using Application.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class InsectService : IInsectService
    {
        private readonly IInsectRepository insectRepository;
        public InsectService(IInsectRepository insectRepository)
        {
            this.insectRepository = insectRepository;
        }
        public List<Insect> GetAll()
        {
            List<Insect> insects = new List<Insect>();
            insects = insectRepository.GetAll();

            return insects;
        }

        public Insect GetById(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            Insect insect = insectRepository.GetById(parsedId);
            if (insect == null)
            {
                throw new Exception("Insect not found");
            }

            return insect;
        }

        public List<Insect> GetByUserId(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            List<Insect> insects = new List<Insect>();
            insects = insectRepository.GetByUserId(parsedId);

            return insects;
        }

        public void Insert(CreateInsect createInsect)
        {
            var insect = new Insect
            {
                Name= createInsect.Name,
                Description= createInsect.Description,
                MinTemperature= createInsect.MinTemperature,
                MaxTemperature= createInsect.MaxTemperature,
                MinHumidity= createInsect.MinHumidity,
                MaxHumidity= createInsect.MaxHumidity,
                MinLivingSpace= createInsect.MinLivingSpace,
                LifeSpan= createInsect.LifeSpan,
                UserId= createInsect.UserId
            };

            insectRepository.Insert(insect);
        }

        public void Update(UpdateInsect updateInsect)
        {
            var insect = GetById(updateInsect.Id);
            insect.Name= updateInsect.Name;
            insect.Description= updateInsect.Description;
            insect.MinTemperature = updateInsect.MinTemperature;
            insect.MaxTemperature = updateInsect.MaxTemperature;
            insect.MinHumidity = updateInsect.MinHumidity;
            insect.MaxHumidity= updateInsect.MaxHumidity;
            insect.MinLivingSpace= updateInsect.MinLivingSpace;
            insect.LifeSpan= updateInsect.LifeSpan;

            insectRepository.Update(insect);
        }

        public void Delete(string id)
        {
            var insect = GetById(id);

            insectRepository.Delete(insect);
        }
    }
}
