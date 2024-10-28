using Microsoft.AspNetCore.SignalR;

namespace PriceFluctuation.ChartHub;
public class LineChartHub : Hub
{
    private readonly Random random = new();

    public async Task SendRandomDataToLineChart()
    {
        int number;
        while (true)
        {
            number = random.Next(0, 100);
            Console.Write($" Sending Random Data Is : {number} ");
            await Clients.All.SendAsync("SendRandomDataToLineChart", number);
            await Task.Delay(5000);
        }
    }
}
