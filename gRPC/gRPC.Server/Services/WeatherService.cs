using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather;
using Grpc.Core;

namespace gRPC
{
    public class WeatherService : Weatherer.WeathererBase
    {
        public override Task<WeatherReply> GetWeather(WeatherRequest request, ServerCallContext context)
        {
            Random rnd = new Random();
            return Task.FromResult(new WeatherReply
            {
                Temperature = rnd.Next(0,30)
            });
        }
    }
}
