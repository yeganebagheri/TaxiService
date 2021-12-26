using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRabbit.Contracts;
using TaxiRabbit.Models;
using Newtonsoft.Json;

namespace TaxiRabbit.Repository
{
    public class ReceiveTripsRepository : IReceiveTripsRepository
    {
        private readonly TripsService _tripsService;
       
        public ReceiveTripsRepository(TripsService tripsService)
        {
            _tripsService = tripsService;
            
        }

        public mw Receive()
        {
            var createdLog = new mw();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var tripmodel = Encoding.UTF8.GetString(body);
                    var json = JsonConvert.DeserializeObject<TripModel>(tripmodel);

                    var message =($" {json.Source} to {json.Destination} With price {json.Cost} Finished!");

                    var createdLog = new mw
                    {
                        Message = message,
                        City = json.City
                    };

                   

                    //var weather = new WeatherService
                    //{
                    //    City = json.City 
                    //};

                   // await _tripsService.CreateAsync(createdLog);
                   // Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                return createdLog;

            }


        }


    }
}
