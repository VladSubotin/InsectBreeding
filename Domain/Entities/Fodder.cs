using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fodder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<InsectFodder> InsectFodders { get; set; }
        public List<LivingPlaseFodder> LivingPlaseFodders { get; set; }
    }
}
