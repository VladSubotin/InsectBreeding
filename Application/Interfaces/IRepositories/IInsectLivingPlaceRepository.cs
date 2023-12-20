using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IInsectLivingPlaceRepository
    {
        InsectLivingPlase GetById(Guid insectId, Guid livingPlaceId);
        void Insert(InsectLivingPlase entity);
        void Update(InsectLivingPlase entity);
        void Delete(InsectLivingPlase entity);
        public List<InsectLivingPlase> GetByLivingPlaceId(Guid id);

    }
}
