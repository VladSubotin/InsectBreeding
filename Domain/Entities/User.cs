﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Insect> Insects { get; set; }
        public List<Fodder> Fodders { get; set; }
        public List<LivingPlace> LivingPlaces { get; set; }
    }
}
