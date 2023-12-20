using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IFodderRepository
    {
        List<Fodder> GetAll();
        Fodder GetById(Guid id);
        void Insert(Fodder entity);
        void Update(Fodder entity);
        void Delete(Fodder entity);
        public List<Fodder> GetByUserId(Guid id);
    }
}
