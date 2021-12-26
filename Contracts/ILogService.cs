using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiRabbit.Models;

namespace TaxiRabbit.Contracts
{
    public interface ILogService
    {
        [AllowAnyStatusCode]
        [Post("api/Trip/CreateTrip")]
        Task<Response<TripDto>> Create([Body] TripDto model);
        //Task<Response<TripDto>> Create([Body] TripDto model);
    }
}
