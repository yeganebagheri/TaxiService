using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiRabbit.Contracts
{
    public interface INumberTripsRepository
    {
        public Task<int> GetNumber();
    }
}
