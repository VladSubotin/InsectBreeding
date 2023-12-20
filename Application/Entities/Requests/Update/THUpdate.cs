using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Requests.Update
{
    public class THUpdate
    {
        public string livingPlaceId { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
}
