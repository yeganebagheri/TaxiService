using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiRabbit.Contracts;
using TaxiRabbit.Models;

namespace TaxiRabbit.Repository
{
    public class NumberTripsRepository : INumberTripsRepository
    {
        private readonly TripsService _tripsService;
        private readonly IReceiveTripsRepository _receiveRepo;

        public NumberTripsRepository(TripsService tripsService, IReceiveTripsRepository ReceiveRepo)
        {
            _tripsService = tripsService;
            _receiveRepo = ReceiveRepo;
        }

        public async Task<int> GetNumber()
        {
            List<LogModel> Number = new List<LogModel>();
            Number = await _tripsService.GetAsync();
            int TripsNumber = Number.Count();
            return TripsNumber;

        }

        
    }
}
