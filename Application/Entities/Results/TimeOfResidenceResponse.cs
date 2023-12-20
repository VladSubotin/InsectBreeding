using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Results
{
    public class TimeOfResidenceResponse
    {
        public int TimeOfResidence { get; set; }
        public int LifeSpan { get; set; }
        public bool TimeIsNotUp { get; set; }
    }
}
