using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IInsectFodderService
    {
        InsectFodder GetById(string insectId, string fodderId);
        void Insert(InsectFodder createInsectFodder);
        void Update(InsectFodder updateInsectFodder);
        void Delete(string insectId, string fodderId);
        public List<InsectFodder> GetByInsectId(string Id);
    }
}
