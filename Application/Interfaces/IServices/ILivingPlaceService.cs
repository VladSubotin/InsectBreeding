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
    public interface ILivingPlaceService
    {
        List<LivingPlace> GetAll();
        LivingPlace GetById(string id);
        void Insert(CreateLivingPlace createLivingPlace);
        void Update(UpdateLivingPlace updateLivingPlace);
        void Delete(string id);
        void UpdateTH(THUpdate THUpdate);
        public List<LivingPlace> GetByUserId(string id);
        public RequiredLivingSpaceResponse CheckRequiredLivingSpace(string id);
    }
}
