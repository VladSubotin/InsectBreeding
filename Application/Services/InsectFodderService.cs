using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class InsectFodderService : IInsectFodderService
    {
        private readonly IInsectFodderRepository insectFodderRepository;
        public InsectFodderService(IInsectFodderRepository insectFodderRepository)
        {
            this.insectFodderRepository = insectFodderRepository;
        }

        public InsectFodder GetById(string insectId, string fodderId)
        {
            Guid parsedinsectId;
            Guid parsedfodderId;
            if (!Guid.TryParse(insectId, out parsedinsectId)
                || !Guid.TryParse(fodderId, out parsedfodderId))
            {
                throw new Exception("Invalid ID format");
            }

            InsectFodder insectFodder = insectFodderRepository.GetById(parsedinsectId, parsedfodderId);
            if (insectFodder == null)
            {
                throw new Exception("InsectFodder not found");
            }

            return insectFodder;
        }

        public List<InsectFodder> GetByInsectId(string id)
        {
            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
            {
                throw new Exception("Invalid ID format");
            }

            List<InsectFodder> insectFodders = new List<InsectFodder>();
            insectFodders = insectFodderRepository.GetByInsectId(parsedId);

            return insectFodders;
        }

        public void Insert(InsectFodder insectFodder)
        {
            insectFodderRepository.Insert(insectFodder);
        }

        public void Update(InsectFodder insectFodder)
        {
            insectFodderRepository.Update(insectFodder);
        }

        public void Delete(string insectId, string fodderId)
        {
            var insectFodder = GetById(insectId, fodderId);

            insectFodderRepository.Delete(insectFodder);
        }
    }
}
