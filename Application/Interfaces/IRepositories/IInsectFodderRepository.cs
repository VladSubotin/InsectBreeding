using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IInsectFodderRepository
    {
        InsectFodder GetById(Guid insectId, Guid fodderId);
        void Insert(InsectFodder entity);
        void Update(InsectFodder entity);
        void Delete(InsectFodder entity);
        public List<InsectFodder> GetByInsectId(Guid id);
    }
}
