using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IInsectRepository
    {
        List<Insect> GetAll();
        Insect GetById(Guid id);
        void Insert(Insect entity);
        void Update(Insect entity);
        void Delete(Insect entity);
        public List<Insect> GetByUserId(Guid id);
    }
}
