using Microsoft.AspNetCore.SignalR;

namespace GoldForecast.ChartHub
{
    public class ForecastHub : Hub
    {
        private readonly Random random = new();

        public async Task SendRandomDataToForecast()
        {
            int plus = random.Next(1, 4);
            int number = 0;
            number += plus;
            Console.WriteLine($"Forecast Number is = {number}");
            await Clients.All.SendAsync("SendRandomDataToForecast", number);
            await Task.Delay(15000);
        }
    }
}
