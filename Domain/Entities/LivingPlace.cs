using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LivingPlace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float LivingSpace { get; set; }
        public DateTime THUpdateDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<LivingPlaseFodder> LivingPlaseFodders { get; set; }
        public List<InsectLivingPlase> InsectLivingPlases { get; set; }

    }
}
