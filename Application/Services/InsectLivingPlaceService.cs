using Application.Interfaces.IServices;
using Application.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.Results;

namespace Application.Services
{
    public class InsectLivingPlaceService : IInsectLivingPlaceService
    {
        private readonly IInsectLivingPlaceRepository insectLivingPlaceRepository;
        private readonly IInsectRepository insectRepository;
        private readonly ILivingPlaceRepository livingPlaceRepository;
        private readonly IInsectFodderRepository insectFodderRepository;
        private readonly ILivingPlaceFodderRepository livingPlaceFodderRepository;
        public InsectLivingPlaceService(IInsectLivingPlaceRepository insectLivingPlaceRepository, 
            IInsectRepository insectRepository, ILivingPlaceRepository livingPlaceRepository, 
            IInsectFodderRepository insectFodderRepository, ILivingPlaceFodderRepository livingPlaceFodderRepository)
        {
            this.insectLivingPlaceRepository = insectLivingPlaceRepository;
            this.insectRepository = insectRepository;
            this.livingPlaceRepository = livingPlaceRepository;
            this.insectFodderRepository = insectFodderRepository;
            this.livingPlaceFodderRepository = livingPlaceFodderRepository;
        }

        public InsectLivingPlase GetById(string insectId, string livingPlaseId)
        {
            Guid parsedinsectId;
            Guid parsedLivingPlaseId;
            if (!Guid.TryParse(insectId, out parsedinsectId)
                || !Guid.TryParse(livingPlaseId, out parsedLivingPlaseId))
            {
                throw new Exception("Invalid ID format");
            }

            InsectLivingPlase insectLivingPlase = insectLivingPlaceRepository.GetById(parsedinsectId, parsedLivingPlaseId);
            if (insectLivingPlase == null)
            {
                throw new Exception("InsectLivingPlace not found");
            }

            return insectLivingPlase;
        }

        public List<InsectLivingPlase> GetByLivingPlaceId(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            List<InsectLivingPlase> insectLivingPlases = new List<InsectLivingPlase>();
            insectLivingPlases = insectLivingPlaceRepository.GetByLivingPlaceId(parsedId);

            return insectLivingPlases;
        }

        public void Insert(InsectLivingPlase insectLivingPlase)
        {
            insectLivingPlaceRepository.Insert(insectLivingPlase);
        }

        public void Update(InsectLivingPlase insectLivingPlase)
        {
            insectLivingPlaceRepository.Update(insectLivingPlase);
        }

        public void Delete(string insectId, string livingPlaseId)
        {
            var insectLivingPlase = GetById(insectId, livingPlaseId);

            insectLivingPlaceRepository.Delete(insectLivingPlase);
        }

        public RequiredTemperatureResponse CheckRequiredTemperature(string insectId, string livingPlaceId)
        {
            var insectLivingPlase = GetById(insectId, livingPlaceId);
            var insect = insectRepository.GetById(insectLivingPlase.InsectId);
            var livingPlace = livingPlaceRepository.GetById(insectLivingPlase.LivingPlaseId);

            return new RequiredTemperatureResponse
            {
                MinRequiredTemperature = insect.MinTemperature,
                MaxRequiredTemperature = insect.MaxTemperature,
                CurrentTemperature = livingPlace.Temperature,
                TemperatureIsFine = insect.MinTemperature <= livingPlace.Temperature 
                    && livingPlace.Temperature <= insect.MaxTemperature
            };
        }

        public RequiredHumidityResponse CheckRequiredHumidity(string insectId, string livingPlaceId)
        {
            var insectLivingPlase = GetById(insectId, livingPlaceId);
            var insect = insectRepository.GetById(insectLivingPlase.InsectId);
            var livingPlace = livingPlaceRepository.GetById(insectLivingPlase.LivingPlaseId);

            return new RequiredHumidityResponse
            {
                MinRequiredHumidity = insect.MinHumidity,
                MaxRequiredHumidity = insect.MaxHumidity,
                CurrentHumidity = livingPlace.Humidity,
                HumidityIsFine = insect.MinHumidity <= livingPlace.Humidity
                    && livingPlace.Humidity <= insect.MaxHumidity
            };
        }

        public RequiredFoddersExistenceResponse CheckRequiredFoddersExistence(string insectId, string livingPlaceId)
        {
            var insectsInLivingPlase = GetById(insectId, livingPlaceId);
            var foddersNeededForInsect = insectFodderRepository.GetByInsectId(insectsInLivingPlase.InsectId);
            var foddersExistedInPlace = livingPlaceFodderRepository.GetByLivingPlaceId(insectsInLivingPlase.LivingPlaseId);
            bool neededFoddersAreExisted = false;

            foreach (LivingPlaseFodder fodderInPlace in foddersExistedInPlace)
            {
                foreach (InsectFodder fodderForInsect in foddersNeededForInsect)
                {
                    if (fodderInPlace.FodderId == fodderForInsect.FodderId)
                    {
                        neededFoddersAreExisted = true;
                        break;
                    }
                }
                if (neededFoddersAreExisted)
                {
                    break;
                }
            }

            return new RequiredFoddersExistenceResponse
            {
                FoddersNeededForInsect = foddersNeededForInsect,
                NeededFoddersAreExisted = neededFoddersAreExisted
            };
        }

        public TimeOfResidenceResponse CheckLivingTimeIsUp(string insectId, string livingPlaceId)
        {
            var insectLivingPlase = GetById(insectId, livingPlaceId);
            var insect = insectRepository.GetById(insectLivingPlase.InsectId);
            int timeOfResidence = (int)(DateTime.Now - insectLivingPlase.SettlementDate).TotalDays;

            return new TimeOfResidenceResponse
            {
                TimeOfResidence = timeOfResidence,
                LifeSpan = insect.LifeSpan,
                TimeIsNotUp = timeOfResidence < insect.LifeSpan
            };
        }
    }
}
