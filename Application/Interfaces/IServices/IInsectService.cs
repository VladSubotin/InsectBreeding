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
    public interface IInsectService
    {
        List<Insect> GetAll();
        Insect GetById(string id);
        void Insert(CreateInsect createInsect);
        void Update(UpdateInsect updateInsect);
        void Delete(string id);
        public List<Insect> GetByUserId(string id);
    }
}
