using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface ILivingPlaceRepository
    {
        List<LivingPlace> GetAll();
        LivingPlace GetById(Guid id);
        void Insert(LivingPlace entity);
        void Update(LivingPlace entity);
        void Delete(LivingPlace entity);
        public List<LivingPlace> GetByUserId(Guid id);
    }
}
