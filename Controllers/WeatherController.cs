using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiRabbit.Contracts;
using TaxiRabbit.Models;

namespace TaxiRabbit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepo;
        private readonly ILogService _logService;
        private readonly INumberTripsRepository _numberTripsRepository;

        public WeatherController(IWeatherRepository weatherRepository, ILogService logService , INumberTripsRepository numberTripsRepository)
        {
            _logService = logService;
            _weatherRepo = weatherRepository;
            _numberTripsRepository = numberTripsRepository;
        }

        [HttpGet("{City}")]
        public async Task<IActionResult> Get(string city)
        {
            int TripsNumber = await _numberTripsRepository.GetNumber();
            int CityTemperature = _weatherRepo.GetTemperature();
             await _logService.Create(new TripDto()
             {
                 TripsNumber = TripsNumber,
                 TemperatureC = CityTemperature
             });
            return Ok(CityTemperature);

        }
    }
}
