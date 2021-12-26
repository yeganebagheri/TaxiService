using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiRabbit.Models;

namespace TaxiRabbit.Repository
{
    public class TripsService
    {
        private readonly IMongoCollection<LogModel> _tripsCollection;

        public TripsService(
            IOptions<TripStoreDatabaseSettings> tripStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                 "mongodb://localhost:27017");

            var mongoDatabase = mongoClient.GetDatabase(
                "TaxiService");

            _tripsCollection = mongoDatabase.GetCollection<LogModel>(
                "Trips");
        }

        public async Task<List<LogModel>> GetAsync() =>
            await _tripsCollection.Find(_ => true).ToListAsync();


        public async Task CreateAsync(LogModel newLog) =>
            await _tripsCollection.InsertOneAsync(newLog);


        public async Task<LogModel> GetAsync(string id) =>
        await _tripsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();


    }
}
