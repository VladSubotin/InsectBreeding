using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Entities.Results;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ILivingPlaceFodderService
    {
        LivingPlaseFodder GetById(string livingPlaceId, string fodderId);
        void Insert(LivingPlaseFodder createLivingPlaceFodder);
        void Update(LivingPlaseFodder updateLivingPlaceFodder);
        void Delete(string insectId, string fodderId);
        public List<LivingPlaseFodder> GetByLivingPlaceId(string id);
        public FodderEnoughVolumeResponse CheckFodderVolumeEnough(string livingPlaceId, string fodderId);
    }
}
