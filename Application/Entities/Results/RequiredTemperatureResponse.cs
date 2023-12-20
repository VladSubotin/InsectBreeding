using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Results
{
    public class RequiredTemperatureResponse
    {
        public bool TemperatureIsFine { get; set; }
        public float MinRequiredTemperature { get; set; }
        public float MaxRequiredTemperature { get; set; }
        public float CurrentTemperature { get; set; }
    }
}
