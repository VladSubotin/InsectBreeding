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
    public interface IFodderService
    {
        List<Fodder> GetAll();
        Fodder GetById(string id);
        void Insert(CreateFodder createFodder);
        void Update(UpdateFodder updateFodder);
        void Delete(string id);
        public List<Fodder> GetByUserId(string id);
    }
}
