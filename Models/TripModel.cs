using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiRabbit.Models
{
    public class TripModel
    {
        public string City { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Cost { get; set; }
        public bool EndTrip { get; set; } = false;
        
        
    }
}
