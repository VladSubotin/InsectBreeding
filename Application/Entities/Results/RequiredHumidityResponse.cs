using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Results
{
    public class RequiredHumidityResponse
    {
        public bool HumidityIsFine { get; set; }
        public float MinRequiredHumidity { get; set; }
        public float MaxRequiredHumidity { get; set; }
        public float CurrentHumidity { get; set; }
    }
}
