using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Results
{
    public class FodderEnoughVolumeResponse
    {
        public float ConsumptionVolumeForInsects { get; set; }
        public bool FodderVolumeIsEnough { get; set; }
    }
}
