using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Results
{
    public class RequiredLivingSpaceResponse
    {
        public float SumVolumeForInsects { get; set; }
        public bool EnoughSpace { get; set; }
    }
}
