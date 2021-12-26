using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiRabbit.Contracts;
using TaxiRabbit.Models;
using TaxiRabbit.Repository;

namespace TaxiRabbit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberTripsController : ControllerBase
    {
        private readonly TripsService _tripsService;
        private readonly ILogService  _logService;
        private readonly INumberTripsRepository _numberTripsRepository;

        public NumberTripsController(TripsService tripsService, INumberTripsRepository numberTripsRepo, ILogService logService)
        {
            _logService = logService;
            _tripsService = tripsService;
            _numberTripsRepository = numberTripsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                
                int TripsNumber = await _numberTripsRepository.GetNumber();
                await _logService.Create(new TripDto()
                {
                    TripsNumber = TripsNumber
                });
                return Ok(TripsNumber);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }
    }
}

