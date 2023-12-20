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
    public interface IInsectLivingPlaceService
    {
        InsectLivingPlase GetById(string insectId, string livingPlaceId);
        void Insert(InsectLivingPlase createInsectLivingPlace);
        void Update(InsectLivingPlase updateInsectLivingPlace);
        void Delete(string insectId, string fodderId);
        public List<InsectLivingPlase> GetByLivingPlaceId(string id);
        public RequiredTemperatureResponse CheckRequiredTemperature(string insectId, string livingPlaceId);
        public RequiredHumidityResponse CheckRequiredHumidity(string insectId, string livingPlaceId);
        public RequiredFoddersExistenceResponse CheckRequiredFoddersExistence(string insectId, string livingPlaceId);
        public TimeOfResidenceResponse CheckLivingTimeIsUp(string insectId, string livingPlaceId);
    }
}
