using Microsoft.AspNetCore.SignalR;

namespace PriceFluctuation.Hub;
public class LineChartHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly Random random = new();

    public async Task SendRandomDataToLineChart()
    {
        int number;
        while (true)
        {
            number = random.Next(0, 500);
            Console.WriteLine($"Sending random number: {number}");
            await Clients.All.SendAsync("RandomData", number);
            await Task.Delay(1000);
        }
    }
}
