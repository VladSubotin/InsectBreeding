using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Entities.Results;
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
    public class LivingPlaceService : ILivingPlaceService
    {
        private readonly ILivingPlaceRepository livingPlaceRepository;
        private readonly IInsectLivingPlaceRepository insectLivingPlaceRepository;
        private readonly IInsectRepository insectRepository;
        public LivingPlaceService(ILivingPlaceRepository livingPlaceRepository, IInsectLivingPlaceRepository insectLivingPlaceRepository, 
            IInsectRepository insectRepository)
        {
            this.livingPlaceRepository = livingPlaceRepository;
            this.insectLivingPlaceRepository = insectLivingPlaceRepository;
            this.insectRepository = insectRepository;
        }
        public List<LivingPlace> GetAll()
        {
            List<LivingPlace> livingPlaces = new List<LivingPlace>();
            livingPlaces = livingPlaceRepository.GetAll();

            return livingPlaces;
        }

        public LivingPlace GetById(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            LivingPlace livingPlace = livingPlaceRepository.GetById(parsedId);
            if (livingPlace == null)
            {
                throw new Exception("LivingPlace not found");
            }

            return livingPlace;
        }

        public List<LivingPlace> GetByUserId(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            List<LivingPlace> livingPlaces = new List<LivingPlace>();
            livingPlaces = livingPlaceRepository.GetByUserId(parsedId);

            return livingPlaces;
        }

        public void Insert(CreateLivingPlace createLivingPlace)
        {
            var livingPlace = new LivingPlace
            {
                Name = createLivingPlace.Name,
                Description = createLivingPlace.Description,
                Location = createLivingPlace.Location,
                Temperature = 0,
                Humidity = 0,
                LivingSpace = createLivingPlace.LivingSpace,
                UserId = createLivingPlace.UserId,
                THUpdateDate = DateTime.Now
            };

            livingPlaceRepository.Insert(livingPlace);
        }

        public void Update(UpdateLivingPlace updateLivingPlace)
        {
            var livingPlace = GetById(updateLivingPlace.Id);
            livingPlace.Name= updateLivingPlace.Name;
            livingPlace.Description= updateLivingPlace.Description;
            livingPlace.Location= updateLivingPlace.Location;
            livingPlace.LivingSpace= updateLivingPlace.LivingSpace;

            livingPlaceRepository.Update(livingPlace);
        }

        public void UpdateTH(THUpdate tHUpdate)
        {
            var livingPlace = GetById(tHUpdate.livingPlaceId);
            livingPlace.Temperature = tHUpdate.Temperature;
            livingPlace.Humidity = tHUpdate.Humidity;
            livingPlace.THUpdateDate = DateTime.Now;

            livingPlaceRepository.Update(livingPlace);
        }

        public void Delete(string id)
        {
            var livingPlace = GetById(id);

            livingPlaceRepository.Delete(livingPlace);
        }

        public RequiredLivingSpaceResponse CheckRequiredLivingSpace(string id)
        {
            var livingPlase = GetById(id);
            List<InsectLivingPlase> insectsInLivingPlace = new List<InsectLivingPlase>();
            insectsInLivingPlace = insectLivingPlaceRepository.GetByLivingPlaceId(livingPlase.Id);
            float sumLivingPlace = 0;

            foreach (var insectInLivingPlace in insectsInLivingPlace)
            {
                var insect = insectRepository.GetById(insectInLivingPlace.InsectId);
                sumLivingPlace += insect.MinLivingSpace * insectInLivingPlace.InsectCount;
            }

            return new RequiredLivingSpaceResponse
            {
                SumVolumeForInsects = sumLivingPlace,
                EnoughSpace = sumLivingPlace <= livingPlase.LivingSpace
            };
        }
    }
}
