using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiRabbit.Contracts
{
    public interface IWeatherRepository
    {
        public int GetTemperature();
    }
}
