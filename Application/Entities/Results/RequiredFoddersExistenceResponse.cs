using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Results
{
    public class RequiredFoddersExistenceResponse
    {
        public List<InsectFodder> FoddersNeededForInsect { get; set; }
        public bool NeededFoddersAreExisted { get; set; }
    }
}
