using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Insect
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public float MinHumidity { get; set; }
        public float MaxHumidity { get; set; }
        public float MinLivingSpace { get; set; }
        public int LifeSpan { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<InsectFodder> InsectFodders { get; set; }
        public List<InsectLivingPlase> InsectLivingPlases { get; set; }

    }
}
