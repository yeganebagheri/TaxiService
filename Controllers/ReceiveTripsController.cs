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
    public class ReceiveTripsController : ControllerBase
    {

        private readonly TripsService _tripsService;
        private readonly IReceiveTripsRepository _receiveRepo;

        public ReceiveTripsController(TripsService tripsService, IReceiveTripsRepository ReceiveRepo)
        {
            _tripsService = tripsService;
            _receiveRepo = ReceiveRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {

            try
            {
                var createdLog = _receiveRepo.Receive();
                var log = createdLog.Message;
                var createdLogmodel = new LogModel
                {
                    Message = log,
                };
                await _tripsService.CreateAsync(createdLogmodel);
                List<LogModel> logmodel = new List<LogModel>();
                logmodel = await _tripsService.GetAsync();
                return Ok(logmodel);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }
    }
}
