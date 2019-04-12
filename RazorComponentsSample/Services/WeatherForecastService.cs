using System;
using System.Linq;
using System.Threading.Tasks;
using Weather;
using Grpc.Core;

namespace RazorComponentsSample.Services
{
    public class WeatherForecastService
    {


        public async Task<WeatherForecast> GetForecastAsync()
        {
            var port = "50051";

            var channel = new Channel("localhost:" + port, ChannelCredentials.Insecure);
            var weathererClient = new Weatherer.WeathererClient(channel);

            var reply = await weathererClient.GetWeatherAsync(new WeatherRequest { Cityid = "1" });

            await channel.ShutdownAsync();
            return await Task.FromResult(new WeatherForecast
            {
                Temperature = reply.Temperature
            });
        }
    }
}
