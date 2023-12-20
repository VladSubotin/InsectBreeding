using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Requests.Create
{
    public class CreateInsect
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public float MinHumidity { get; set; }
        public float MaxHumidity { get; set; }
        public float MinLivingSpace { get; set; }
        public int LifeSpan { get; set; }
        public Guid UserId { get; set; }
    }
}
