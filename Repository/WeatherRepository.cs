using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiRabbit.Contracts;
using TaxiRabbit.Models;

namespace TaxiRabbit.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IReceiveTripsRepository _receiveRepo;

        public WeatherRepository(IReceiveTripsRepository receiveTripsRepository)
        {
            _receiveRepo = receiveTripsRepository;
            
        }

        public int GetTemperature()
        {

            var mw = _receiveRepo.Receive();
            var city = mw.City;
            var rng = new Random();
            WeatherService res = new WeatherService
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(10, 30),
                City = city
            };
            return res.TemperatureC;
            

        }

    }
}
