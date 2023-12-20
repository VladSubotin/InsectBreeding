using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.Results;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.Services
{
    public class LivingPlaceFodderService : ILivingPlaceFodderService
    {
        private readonly ILivingPlaceFodderRepository livingPlaceFodderRepository;
        private readonly IInsectLivingPlaceRepository insectLivingPlaceRepository;
        private readonly IInsectFodderRepository insectFodderRepository;
        public LivingPlaceFodderService(ILivingPlaceFodderRepository livingPlaceFodderRepository, IInsectLivingPlaceRepository insectLivingPlaceRepository,
            IInsectFodderRepository insectFodderRepository)
        {
            this.livingPlaceFodderRepository = livingPlaceFodderRepository;
            this.insectLivingPlaceRepository = insectLivingPlaceRepository;
            this.insectFodderRepository = insectFodderRepository;
        }

        public LivingPlaseFodder GetById(string livingPlaseId, string fodderId)
        {
            Guid parsedlivingPlaseId;
            Guid parsedfodderId;
            if (!Guid.TryParse(livingPlaseId, out parsedlivingPlaseId)
                || !Guid.TryParse(fodderId, out parsedfodderId))
            {
                throw new Exception("Invalid ID format");
            }

            LivingPlaseFodder livingPlaseFodder = livingPlaceFodderRepository.GetById(parsedlivingPlaseId, parsedfodderId);
            if (livingPlaseFodder == null)
            {
                throw new Exception("LivingPlaceFodder not found");
            }

            return livingPlaseFodder;
        }

        public List<LivingPlaseFodder> GetByLivingPlaceId(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            List<LivingPlaseFodder> livingPlaseFodders = new List<LivingPlaseFodder>();
            livingPlaseFodders = livingPlaceFodderRepository.GetByLivingPlaceId(parsedId);

            return livingPlaseFodders;
        }

        public void Insert(LivingPlaseFodder livingPlaseFodder)
        {
            livingPlaceFodderRepository.Insert(livingPlaseFodder);
        }

        public void Update(LivingPlaseFodder livingPlaseFodder)
        {
            livingPlaceFodderRepository.Update(livingPlaseFodder);
        }

        public void Delete(string livingPlaseId, string fodderId)
        {
            var insectFodder = GetById(livingPlaseId, fodderId);

            livingPlaceFodderRepository.Delete(insectFodder);
        }

        public FodderEnoughVolumeResponse CheckFodderVolumeEnough(string livingPlaceId, string fodderId)
        {
            var fodderInPlace = GetById(livingPlaceId, fodderId);
            var insectsInPlace = insectLivingPlaceRepository.GetByLivingPlaceId(fodderInPlace.LivingPlaseId);
            float consumptionVolumeForInsects = 0;

            foreach (var insectInPlace in insectsInPlace)
            {
                var fodderForInsect = insectFodderRepository.GetById(insectInPlace.InsectId, fodderInPlace.FodderId);
                consumptionVolumeForInsects += (fodderForInsect?.FodderConsumptionVolume ?? 0) * insectInPlace.InsectCount;
            }

            return new FodderEnoughVolumeResponse
            {
                ConsumptionVolumeForInsects = consumptionVolumeForInsects,
                FodderVolumeIsEnough = fodderInPlace.FodderVolume >= consumptionVolumeForInsects
            };
        }
    }
}
