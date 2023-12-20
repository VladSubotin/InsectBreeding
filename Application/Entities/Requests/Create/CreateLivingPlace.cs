using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Requests.Create
{
    public class CreateLivingPlace
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public float LivingSpace { get; set; }
        public Guid UserId { get; set; }
    }
}
