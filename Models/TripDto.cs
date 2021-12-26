using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiRabbit.Models
{
    public class TripDto
    {
        public string City { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }
        public int PassengerNationalCode { get; set; }
        public int TripsNumber { get; set; }
        public int TemperatureC { get; set; }
    }
}
