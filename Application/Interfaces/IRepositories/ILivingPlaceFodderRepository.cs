using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface ILivingPlaceFodderRepository
    {
        LivingPlaseFodder GetById(Guid livingPlaceId, Guid fodderId);
        void Insert(LivingPlaseFodder entity);
        void Update(LivingPlaseFodder entity);
        void Delete(LivingPlaseFodder entity);
        public List<LivingPlaseFodder> GetByLivingPlaceId(Guid id);
    }
}
